// Copyright 2024 The argocd-dotnet-client Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Session.Responses;
using Json.Patch;
using k8s;
using k8s.Models;

namespace ArgoCD.Client.Test.Utilities
{
    internal class ArgoCDKubernetesFixture : IAsyncLifetime
    {
        private static JsonSerializerOptions serializerOptions =
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };

        private const string InstallFilePath = "/testconfig/install.yaml";
        private const string kubeConfigFilePath = "/testconfig/kubeconfig.yaml";
        private const string AdminSecretName = "argocd-initial-admin-secret";
        private const string ServerName = "argocd-server";
        private const string NameSpace = "argocd";

        private static readonly TemplateString SolutionRootFolder = "${PWD}/../../../../..";
        public static string Password { get; private set; }
        public static string Token { get; private set; }

        public static string ArgoCDHost { get; private set; }
        private IList<object> resourceList;
        private IKubernetes kubernetes;

        public async Task InitializeAsync()
        {
            await StartKubernetesAsync();
            await InitializeDataAsync();
        }

        public  Task DisposeAsync()
        {
            kubernetes?.Dispose();
            resourceList?.Clear();
            return Task.CompletedTask;
        }
        private async Task StartKubernetesAsync()
        {
            var config = KubernetesClientConfiguration.BuildDefaultConfig();
            if (config.Host == "http://localhost:8080")
            {
                config = KubernetesClientConfiguration.BuildConfigFromConfigFile(
                    $"{SolutionRootFolder}/{kubeConfigFilePath}");
            }

            kubernetes = new Kubernetes(config);

#if NET5_0 || NETSTANDARD2_1
            resourceList = await k8s.Yaml.LoadAllFromFileAsync($"{SolutionRootFolder}/{InstallFilePath}");
#else
                        resourceList = await KubernetesYaml.LoadAllFromFileAsync($"{SolutionRootFolder}/{InstallFilePath}");
#endif

            // Ensure this line is added at the top of the file with other using directives
            await RestartAsync();
        }


        private async Task RestartAsync()
        {
            await UninstallAsync();
            await CreateNameSpaceAsync();
            foreach (object item in resourceList)
            {
                var objectMeta = (IKubernetesObject<V1ObjectMeta>)item;
                string fieldSelector = $"metadata.name={objectMeta.Name()},metadata.namespace={NameSpace}";
                await ApplyForKubernetesAsync(objectMeta, item, fieldSelector);
            }
        }

        private async Task InitializeDataAsync()
        {
            int port = await FindPortAsync();
            ArgoCDHost = $"https://localhost:{port}/api/v1/";
            await LoadAsync();
        }

        private async Task<string> FindPasswordAsync()
        {
#if NET5_0 || NETSTANDARD2_1
            var secretList = await kubernetes.ListNamespacedSecretAsync(NameSpace, fieldSelector: $"metadata.name={AdminSecretName}");
#else
  var secretList = await kubernetes.CoreV1.ListNamespacedSecretAsync(NameSpace, null, null, $"metadata.name={AdminSecretName}");
#endif

            var adminSecret = secretList.Items.FirstOrDefault(q => q.Metadata.Name.Equals(AdminSecretName)) ?? throw new Exception($"{AdminSecretName} secret not found");

            bool ok = adminSecret.Data.TryGetValue("password", out byte[] password);
            Assert.True(ok);
            return Encoding.UTF8.GetString(password);
        }


        private async Task<int> FindPortAsync()
        {
#if NET5_0 || NETSTANDARD2_1
            var serviceList = await kubernetes.ListNamespacedServiceAsync(NameSpace, fieldSelector: $"metadata.name={ServerName}");
#else
     var serviceList = await kubernetes.CoreV1.ListNamespacedServiceAsync(NameSpace, null, null, $"metadata.name={ServerName}");
#endif

            var service = serviceList.Items.FirstOrDefault(q => q.Metadata.Name.Equals(ServerName)) ?? throw new Exception($"{ServerName} service not found");
            Assert.Equal("NodePort", service.Spec.Type, true);
            return service.Spec.Ports.First(q => q.Name == "http").NodePort ?? default;
        }

        private async Task LoadAsync()
        {
            int maxRetries = 10;
            int delay = 5000;

            using var client = new HttpClient(ArgoCDApiHelper.CreateHandler());
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    Console.WriteLine($"Waiting {delay / 1000} seconds before retry...");
                    await Task.Delay(delay);

                    Password = await FindPasswordAsync();

                    string sessionJsonData = JsonSerializer.Serialize(new { username = ArgoCDApiHelper.TestUserNameWithAdmin, password = Password });
                    using HttpContent sessionContent = new StringContent(sessionJsonData);
                    sessionContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var sessionResponse = await client.PostAsync($"{ArgoCDHost}session", sessionContent);

                    sessionResponse.EnsureSuccessStatusCode();
                    string tokenJsonData =
                        JsonSerializer.Serialize(new { expiresIn = 3600, id = "test", name = "test" });
                    using HttpContent tokenContent = new StringContent(tokenJsonData);
                    tokenContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var tokenResponse =
                        await client.PostAsync($"{ArgoCDHost}account/{ArgoCDApiHelper.TestUserNameWithAdmin}/token", tokenContent);
                    tokenResponse.EnsureSuccessStatusCode();

                    string tokenStr = await tokenResponse.Content.ReadAsStringAsync();
                    var session = JsonSerializer.Deserialize<Session>(tokenStr, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    Token = session.Token;
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    if (attempt == maxRetries)
                    {
                        throw new Exception("Max retry attempts reached.");
                    }
                }
            }
        }

#if NET5_0 || NETSTANDARD2_1
        private async Task ApplyForKubernetesAsync(IKubernetesObject<V1ObjectMeta> objectMeta, object resource,
       string fieldSelector)
        {
            switch (objectMeta.Kind)
            {
                case V1CustomResourceDefinition.KubeKind:
                    var newDefinition = (V1CustomResourceDefinition)resource;

                    var definitionList =
                        await kubernetes.ListCustomResourceDefinitionAsync(null,null,fieldSelector,
                            null);
                    if (!definitionList.Items.Any())
                    {
                        _ = await kubernetes.CreateCustomResourceDefinitionAsync(newDefinition);
                    }
                    else
                    {
                        var oldDefinition = definitionList.Items.First();
                        _ = await kubernetes.PatchCustomResourceDefinitionAsync(
                            new V1Patch(CreatePathData(newDefinition, oldDefinition), V1Patch.PatchType.JsonPatch),
                            newDefinition.Name());
                    }

                    break;
                case V1ServiceAccount.KubeKind:
                    var newServiceAccount = (V1ServiceAccount)resource;

                    var serviceAccountList =
                        await kubernetes.ListNamespacedServiceAccountAsync(NameSpace, null, null, fieldSelector);
                    if (!serviceAccountList.Items.Any())
                    {
                        _ = await kubernetes.CreateNamespacedServiceAccountAsync(newServiceAccount, NameSpace);
                    }
                    else
                    {
                        var oldServiceAccount = serviceAccountList.Items.First();
                        _ = await kubernetes.PatchNamespacedServiceAccountAsync(
                            new V1Patch(CreatePathData(newServiceAccount, oldServiceAccount),
                                V1Patch.PatchType.JsonPatch), oldServiceAccount.Name(), oldServiceAccount.Namespace());
                    }

                    break;
                case V1Role.KubeKind:
                    var newRole = (V1Role)resource;

                    var roleList =
                        await kubernetes.ListNamespacedRoleAsync(NameSpace, null, null,
                            fieldSelector);
                    if (!roleList.Items.Any())
                    {
                        _ = await kubernetes.CreateNamespacedRoleAsync(newRole, NameSpace);
                    }
                    else
                    {
                        var oldRole = roleList.Items.First();
                        _ = await kubernetes.PatchNamespacedRoleAsync(
                            new V1Patch(CreatePathData(newRole, oldRole), V1Patch.PatchType.JsonPatch), oldRole.Name(),
                            oldRole.Namespace());
                    }

                    break;
                case V1ClusterRole.KubeKind:
                    var newClusterRole = (V1ClusterRole)resource;

                    var clusterRoleList =
                        await kubernetes.ListClusterRoleAsync(null, null, fieldSelector);
                    if (!clusterRoleList.Items.Any())
                    {
                        _ = await kubernetes.CreateClusterRoleAsync(newClusterRole);
                    }
                    else
                    {
                        var oldClusterRole = clusterRoleList.Items.First();
                        _ = await kubernetes.PatchClusterRoleAsync(
                            new V1Patch(CreatePathData(newClusterRole, oldClusterRole), V1Patch.PatchType.JsonPatch),
                            oldClusterRole.Name());
                    }

                    break;
                case V1RoleBinding.KubeKind:
                    var newRoleBinding = (V1RoleBinding)resource;

                    var roleBindingList =
                        await kubernetes.ListRoleBindingForAllNamespacesAsync(null, null,
                            fieldSelector);
                    if (!roleBindingList.Items.Any())
                    {
                        _ = await kubernetes.CreateNamespacedRoleBindingAsync(newRoleBinding,
                            NameSpace);
                    }
                    else
                    {
                        var oldRoleBinding = roleBindingList.Items.First();
                        _ = await kubernetes.PatchNamespacedRoleBindingAsync(
                            new V1Patch(CreatePathData(newRoleBinding, oldRoleBinding), V1Patch.PatchType.JsonPatch),
                            oldRoleBinding.Name(), oldRoleBinding.Namespace());
                    }

                    break;
                case V1ClusterRoleBinding.KubeKind:
                    var newClusterRoleBinding = (V1ClusterRoleBinding)resource;

                    var clusterRoleBindingList =
                        await kubernetes.ListClusterRoleBindingAsync(null, null, fieldSelector);
                    if (!clusterRoleBindingList.Items.Any())
                    {
                        _ = await kubernetes.CreateClusterRoleBindingAsync(newClusterRoleBinding);
                    }
                    else
                    {
                        var oldClusterRoleBinding = clusterRoleBindingList.Items.First();
                        _ = await kubernetes.PatchClusterRoleBindingAsync(
                            new V1Patch(CreatePathData(newClusterRoleBinding, oldClusterRoleBinding),
                                V1Patch.PatchType.JsonPatch), oldClusterRoleBinding.Name());
                    }

                    break;
                case V1ConfigMap.KubeKind:
                    var newConfigMap = (V1ConfigMap)resource;

                    var configMapList =
                        await kubernetes.ListConfigMapForAllNamespacesAsync(null, null, fieldSelector);
                    if (!configMapList.Items.Any())
                    {
                        _ = await kubernetes.CreateNamespacedConfigMapAsync(newConfigMap, NameSpace);
                    }
                    else
                    {
                        var oldConfigMap = configMapList.Items.First();
                        _ = await kubernetes.PatchNamespacedConfigMapAsync(
                            new V1Patch(CreatePathData(newConfigMap, oldConfigMap), V1Patch.PatchType.JsonPatch),
                            oldConfigMap.Name(), oldConfigMap.Namespace());
                    }

                    break;
                case V1Secret.KubeKind:
                    var newSecret = (V1Secret)resource;
                    var secretList = await kubernetes.ListSecretForAllNamespacesAsync(null, null, fieldSelector);
                    if (!secretList.Items.Any())
                    {
                        _ = await kubernetes.CreateNamespacedSecretAsync(newSecret, NameSpace);
                    }
                    else
                    {
                        var oldSecret = secretList.Items.First();
                        _ = await kubernetes.PatchNamespacedSecretAsync(
                            new V1Patch(CreatePathData(newSecret, oldSecret), V1Patch.PatchType.JsonPatch),
                            oldSecret.Name(), oldSecret.Namespace());
                    }

                    break;
                case V1Service.KubeKind:
                    var newService = (V1Service)resource;
                    var serviceList =
                        await kubernetes.ListNamespacedServiceAsync(NameSpace, null, null, fieldSelector);
                    if (!serviceList.Items.Any())
                    {
                        _ = await kubernetes.CreateNamespacedServiceAsync(newService, NameSpace);
                    }
                    else
                    {
                        var oldService = serviceList.Items.First();
                        _ = await kubernetes.PatchNamespacedServiceAsync(
                            new V1Patch(CreatePathData(newService, oldService), V1Patch.PatchType.JsonPatch),
                            oldService.Name(), oldService.Namespace());
                    }

                    break;
                case V1Deployment.KubeKind:
                    var newDeployment = (V1Deployment)resource;
                    var deploymentList =
                        await kubernetes.ListDeploymentForAllNamespacesAsync(null, null, fieldSelector);
                    if (!deploymentList.Items.Any())
                    {
                        _ = await kubernetes.CreateNamespacedDeploymentAsync(newDeployment, NameSpace);
                    }
                    else
                    {
                        var oldDeployment = deploymentList.Items.First();
                        _ = await kubernetes.PatchNamespacedDeploymentAsync(
                            new V1Patch(CreatePathData(newDeployment, oldDeployment), V1Patch.PatchType.JsonPatch),
                            oldDeployment.Name(), oldDeployment.Namespace());
                    }

                    break;
                case V1StatefulSet.KubeKind:
                    var newStatefulSet = (V1StatefulSet)resource;
                    var statefulSetList =
                        await kubernetes.ListStatefulSetForAllNamespacesAsync(null, null, fieldSelector);
                    if (!statefulSetList.Items.Any())
                    {
                        _ = await kubernetes.CreateNamespacedStatefulSetAsync(newStatefulSet, NameSpace);
                    }
                    else
                    {
                        var oldStatefulSet = statefulSetList.Items.First();
                        _ = await kubernetes.PatchNamespacedStatefulSetAsync(
                            new V1Patch(CreatePathData(newStatefulSet, oldStatefulSet), V1Patch.PatchType.JsonPatch),
                            oldStatefulSet.Name(), oldStatefulSet.Namespace());
                    }

                    break;
                case V1NetworkPolicy.KubeKind:
                    var newNetworkPolicy = (V1NetworkPolicy)resource;
                    var networkPolicyList =
                        await kubernetes.ListNetworkPolicyForAllNamespacesAsync(null, null, fieldSelector);
                    if (!networkPolicyList.Items.Any())
                    {
                        _ = await kubernetes.CreateNamespacedNetworkPolicyAsync(newNetworkPolicy,
                            NameSpace);
                    }
                    else
                    {
                        var oldNetworkPolicy = networkPolicyList.Items.First();
                        _ = await kubernetes.PatchNamespacedNetworkPolicyAsync(
                            new V1Patch(CreatePathData(newNetworkPolicy, oldNetworkPolicy),
                                V1Patch.PatchType.JsonPatch), oldNetworkPolicy.Name(), oldNetworkPolicy.Namespace());
                    }

                    break;
                default:
                    throw new NotImplementedException($"{objectMeta.Kind} not implemented!");
            }
        }
#else
        private async Task ApplyForKubernetesAsync(IKubernetesObject<V1ObjectMeta> objectMeta, object resource,
            string fieldSelector)
        {
            switch (objectMeta.Kind)
            {
                case V1CustomResourceDefinition.KubeKind:
                    var newDefinition = (V1CustomResourceDefinition)resource;

                    var definitionList =
                        await kubernetes.ApiextensionsV1.ListCustomResourceDefinitionAsync(null, null, fieldSelector,
                            null);
                    if (!definitionList.Items.Any())
                    {
                        _ = await kubernetes.ApiextensionsV1.CreateCustomResourceDefinitionAsync(newDefinition);
                    }
                    else
                    {
                        var oldDefinition = definitionList.Items.First();
                        _ = await kubernetes.ApiextensionsV1.PatchCustomResourceDefinitionAsync(
                            new V1Patch(CreatePathData(newDefinition, oldDefinition), V1Patch.PatchType.JsonPatch),
                            newDefinition.Name());
                    }

                    break;
                case V1ServiceAccount.KubeKind:
                    var newServiceAccount = (V1ServiceAccount)resource;

                    var serviceAccountList =
                        await kubernetes.CoreV1.ListNamespacedServiceAccountAsync(NameSpace, null, null, fieldSelector);
                    if (!serviceAccountList.Items.Any())
                    {
                        _ = await kubernetes.CoreV1.CreateNamespacedServiceAccountAsync(newServiceAccount, NameSpace);
                    }
                    else
                    {
                        var oldServiceAccount = serviceAccountList.Items.First();
                        _ = await kubernetes.CoreV1.PatchNamespacedServiceAccountAsync(
                            new V1Patch(CreatePathData(newServiceAccount, oldServiceAccount),
                                V1Patch.PatchType.JsonPatch), oldServiceAccount.Name(), oldServiceAccount.Namespace());
                    }

                    break;
                case V1Role.KubeKind:
                    var newRole = (V1Role)resource;

                    var roleList =
                        await kubernetes.RbacAuthorizationV1.ListNamespacedRoleAsync(NameSpace, null, null,
                            fieldSelector);
                    if (!roleList.Items.Any())
                    {
                        _ = await kubernetes.RbacAuthorizationV1.CreateNamespacedRoleAsync(newRole, NameSpace);
                    }
                    else
                    {
                        var oldRole = roleList.Items.First();
                        _ = await kubernetes.RbacAuthorizationV1.PatchNamespacedRoleAsync(
                            new V1Patch(CreatePathData(newRole, oldRole), V1Patch.PatchType.JsonPatch), oldRole.Name(),
                            oldRole.Namespace());
                    }

                    break;
                case V1ClusterRole.KubeKind:
                    var newClusterRole = (V1ClusterRole)resource;

                    var clusterRoleList =
                        await kubernetes.RbacAuthorizationV1.ListClusterRoleAsync(null, null, fieldSelector);
                    if (!clusterRoleList.Items.Any())
                    {
                        _ = await kubernetes.RbacAuthorizationV1.CreateClusterRoleAsync(newClusterRole);
                    }
                    else
                    {
                        var oldClusterRole = clusterRoleList.Items.First();
                        _ = await kubernetes.RbacAuthorizationV1.PatchClusterRoleAsync(
                            new V1Patch(CreatePathData(newClusterRole, oldClusterRole), V1Patch.PatchType.JsonPatch),
                            oldClusterRole.Name());
                    }

                    break;
                case V1RoleBinding.KubeKind:
                    var newRoleBinding = (V1RoleBinding)resource;

                    var roleBindingList =
                        await kubernetes.RbacAuthorizationV1.ListRoleBindingForAllNamespacesAsync(null, null,
                            fieldSelector);
                    if (!roleBindingList.Items.Any())
                    {
                        _ = await kubernetes.RbacAuthorizationV1.CreateNamespacedRoleBindingAsync(newRoleBinding,
                            NameSpace);
                    }
                    else
                    {
                        var oldRoleBinding = roleBindingList.Items.First();
                        _ = await kubernetes.RbacAuthorizationV1.PatchNamespacedRoleBindingAsync(
                            new V1Patch(CreatePathData(newRoleBinding, oldRoleBinding), V1Patch.PatchType.JsonPatch),
                            oldRoleBinding.Name(), oldRoleBinding.Namespace());
                    }

                    break;
                case V1ClusterRoleBinding.KubeKind:
                    var newClusterRoleBinding = (V1ClusterRoleBinding)resource;

                    var clusterRoleBindingList =
                        await kubernetes.RbacAuthorizationV1.ListClusterRoleBindingAsync(null, null, fieldSelector);
                    if (!clusterRoleBindingList.Items.Any())
                    {
                        _ = await kubernetes.RbacAuthorizationV1.CreateClusterRoleBindingAsync(newClusterRoleBinding);
                    }
                    else
                    {
                        var oldClusterRoleBinding = clusterRoleBindingList.Items.First();
                        _ = await kubernetes.RbacAuthorizationV1.PatchClusterRoleBindingAsync(
                            new V1Patch(CreatePathData(newClusterRoleBinding, oldClusterRoleBinding),
                                V1Patch.PatchType.JsonPatch), oldClusterRoleBinding.Name());
                    }

                    break;
                case V1ConfigMap.KubeKind:
                    var newConfigMap = (V1ConfigMap)resource;

                    var configMapList =
                        await kubernetes.CoreV1.ListConfigMapForAllNamespacesAsync(null, null, fieldSelector);
                    if (!configMapList.Items.Any())
                    {
                        _ = await kubernetes.CoreV1.CreateNamespacedConfigMapAsync(newConfigMap, NameSpace);
                    }
                    else
                    {
                        var oldConfigMap = configMapList.Items.First();
                        _ = await kubernetes.CoreV1.PatchNamespacedConfigMapAsync(
                            new V1Patch(CreatePathData(newConfigMap, oldConfigMap), V1Patch.PatchType.JsonPatch),
                            oldConfigMap.Name(), oldConfigMap.Namespace());
                    }

                    break;
                case V1Secret.KubeKind:
                    var newSecret = (V1Secret)resource;
                    var secretList = await kubernetes.CoreV1.ListSecretForAllNamespacesAsync(null, null, fieldSelector);
                    if (!secretList.Items.Any())
                    {
                        _ = await kubernetes.CoreV1.CreateNamespacedSecretAsync(newSecret, NameSpace);
                    }
                    else
                    {
                        var oldSecret = secretList.Items.First();
                        _ = await kubernetes.CoreV1.PatchNamespacedSecretAsync(
                            new V1Patch(CreatePathData(newSecret, oldSecret), V1Patch.PatchType.JsonPatch),
                            oldSecret.Name(), oldSecret.Namespace());
                    }

                    break;
                case V1Service.KubeKind:
                    var newService = (V1Service)resource;
                    var serviceList =
                        await kubernetes.CoreV1.ListNamespacedServiceAsync(NameSpace, null, null, fieldSelector);
                    if (!serviceList.Items.Any())
                    {
                        _ = await kubernetes.CoreV1.CreateNamespacedServiceAsync(newService, NameSpace);
                    }
                    else
                    {
                        var oldService = serviceList.Items.First();
                        _ = await kubernetes.CoreV1.PatchNamespacedServiceAsync(
                            new V1Patch(CreatePathData(newService, oldService), V1Patch.PatchType.JsonPatch),
                            oldService.Name(), oldService.Namespace());
                    }

                    break;
                case V1Deployment.KubeKind:
                    var newDeployment = (V1Deployment)resource;
                    var deploymentList =
                        await kubernetes.AppsV1.ListDeploymentForAllNamespacesAsync(null, null, fieldSelector);
                    if (!deploymentList.Items.Any())
                    {
                        _ = await kubernetes.AppsV1.CreateNamespacedDeploymentAsync(newDeployment, NameSpace);
                    }
                    else
                    {
                        var oldDeployment = deploymentList.Items.First();
                        _ = await kubernetes.AppsV1.PatchNamespacedDeploymentAsync(
                            new V1Patch(CreatePathData(newDeployment, oldDeployment), V1Patch.PatchType.JsonPatch),
                            oldDeployment.Name(), oldDeployment.Namespace());
                    }

                    break;
                case V1StatefulSet.KubeKind:
                    var newStatefulSet = (V1StatefulSet)resource;
                    var statefulSetList =
                        await kubernetes.AppsV1.ListStatefulSetForAllNamespacesAsync(null, null, fieldSelector);
                    if (!statefulSetList.Items.Any())
                    {
                        _ = await kubernetes.AppsV1.CreateNamespacedStatefulSetAsync(newStatefulSet, NameSpace);
                    }
                    else
                    {
                        var oldStatefulSet = statefulSetList.Items.First();
                        _ = await kubernetes.AppsV1.PatchNamespacedStatefulSetAsync(
                            new V1Patch(CreatePathData(newStatefulSet, oldStatefulSet), V1Patch.PatchType.JsonPatch),
                            oldStatefulSet.Name(), oldStatefulSet.Namespace());
                    }

                    break;
                case V1NetworkPolicy.KubeKind:
                    var newNetworkPolicy = (V1NetworkPolicy)resource;
                    var networkPolicyList =
                        await kubernetes.NetworkingV1.ListNetworkPolicyForAllNamespacesAsync(null, null, fieldSelector);
                    if (!networkPolicyList.Items.Any())
                    {
                        _ = await kubernetes.NetworkingV1.CreateNamespacedNetworkPolicyAsync(newNetworkPolicy,
                            NameSpace);
                    }
                    else
                    {
                        var oldNetworkPolicy = networkPolicyList.Items.First();
                        _ = await kubernetes.NetworkingV1.PatchNamespacedNetworkPolicyAsync(
                            new V1Patch(CreatePathData(newNetworkPolicy, oldNetworkPolicy),
                                V1Patch.PatchType.JsonPatch), oldNetworkPolicy.Name(), oldNetworkPolicy.Namespace());
                    }

                    break;
                default:
                    throw new NotImplementedException($"{objectMeta.Kind} not implemented!");
            }
        }
#endif
        private async Task UninstallAsync()
        {
            foreach (object item in resourceList)
            {
                var objectMeta = (IKubernetesObject<V1ObjectMeta>)item;
                string resourceFieldSelector = $"metadata.name={objectMeta.Name()}";
                await DeleteResourceAsync(objectMeta, resourceFieldSelector);
            }

            string fieldSelector = $"metadata.name={NameSpace}";
            var tcs = new TaskCompletionSource<bool>();

            V1Namespace GetNamespace()
            {
#if NET5_0 || NETSTANDARD2_1
                V1NamespaceList nameSpaceList = kubernetes.ListNamespace(
                    pretty: "false",
                    allowWatchBookmarks: null,
                    fieldSelector: fieldSelector
                );
#else
    V1NamespaceList nameSpaceList = kubernetes.CoreV1.ListNamespace(
                    pretty: false,
                    allowWatchBookmarks: null,
                    fieldSelector: fieldSelector
                );
#endif
                return nameSpaceList.Items.FirstOrDefault();
            }

            try
            {
                var nameSpaceInfo = GetNamespace();
                if (nameSpaceInfo is null)
                {
                    return;
                }
#if NET5_0 || NETSTANDARD2_1
                await kubernetes.DeleteNamespaceAsync(NameSpace);

                var watch = await kubernetes.ListNamespaceWithHttpMessagesAsync(
                    watch: true,
                    fieldSelector: fieldSelector);
#else
       await kubernetes.CoreV1.DeleteNamespaceAsync(NameSpace);

                var watch = await kubernetes.CoreV1.ListNamespaceWithHttpMessagesAsync(
                    watch: true,
                    fieldSelector: fieldSelector);
#endif
                using var _ = watch.Watch<V1Namespace, V1NamespaceList>(
                    onEvent: (type, item) =>
                    {
                        if (type == WatchEventType.Deleted && item.Metadata?.Name == NameSpace)
                        {
                            var watchV1Namespace = GetNamespace();
                            Console.WriteLine($"watch {watchV1Namespace == null}");
                            if (watchV1Namespace is null)
                            {
                                tcs.TrySetResult(true);
                            }
                        }
                    });
                await tcs.Task;
                ;
            }
            catch (Exception ex)
            {
                tcs.SetCanceled();
                Console.WriteLine(ex.Message);
            }
        }

#if NET5_0 || NETSTANDARD2_1
        private async Task DeleteResourceAsync(IKubernetesObject<V1ObjectMeta> objectMeta, string fieldSelector)
        {
            switch (objectMeta.Kind)
            {
                case V1CustomResourceDefinition.KubeKind:
                    var definitionList =
                        await kubernetes.ListCustomResourceDefinitionAsync(null, null, fieldSelector,
                            null);
                    if (definitionList.Items.Any())
                    {
                        _ = await kubernetes.DeleteCustomResourceDefinitionAsync(objectMeta.Name());
                    }

                    break;

                case V1ClusterRole.KubeKind:
                    var clusterRoleList =
                        await kubernetes.ListClusterRoleAsync(null, null, fieldSelector);
                    if (clusterRoleList.Items.Any())
                    {
                        _ = await kubernetes.DeleteClusterRoleAsync(objectMeta.Name());
                    }

                    break;

                case V1ClusterRoleBinding.KubeKind:
                    var clusterRoleBindingList =
                        await kubernetes.ListClusterRoleBindingAsync(null, null, fieldSelector);
                    if (clusterRoleBindingList.Items.Any())
                    {
                        _ = await kubernetes.DeleteClusterRoleBindingAsync(objectMeta.Name());
                    }

                    break;
            }
        }
#else
        private async Task DeleteResourceAsync(IKubernetesObject<V1ObjectMeta> objectMeta, string fieldSelector)
        {
            switch (objectMeta.Kind)
            {
                case V1CustomResourceDefinition.KubeKind:
                    var definitionList =
                        await kubernetes.ApiextensionsV1.ListCustomResourceDefinitionAsync(null, null, fieldSelector,
                            null);
                    if (definitionList.Items.Any())
                    {
                        _ = await kubernetes.ApiextensionsV1.DeleteCustomResourceDefinitionAsync(objectMeta.Name());
                    }

                    break;

                case V1ClusterRole.KubeKind:
                    var clusterRoleList =
                        await kubernetes.RbacAuthorizationV1.ListClusterRoleAsync(null, null, fieldSelector);
                    if (clusterRoleList.Items.Any())
                    {
                        _ = await kubernetes.RbacAuthorizationV1.DeleteClusterRoleAsync(objectMeta.Name());
                    }

                    break;

                case V1ClusterRoleBinding.KubeKind:
                    var clusterRoleBindingList =
                        await kubernetes.RbacAuthorizationV1.ListClusterRoleBindingAsync(null, null, fieldSelector);
                    if (clusterRoleBindingList.Items.Any())
                    {
                        _ = await kubernetes.RbacAuthorizationV1.DeleteClusterRoleBindingAsync(objectMeta.Name());
                    }

                    break;
            }
        }
#endif

        private async Task CreateNameSpaceAsync()
        {
            try
            {
#if NET5_0 || NETSTANDARD2_1
                await kubernetes.CreateNamespaceAsync(new V1Namespace()
                {
                    Metadata = new V1ObjectMeta() { Name = NameSpace }
                });
#else
    await kubernetes.CoreV1.CreateNamespaceAsync(new V1Namespace()
                {
                    Metadata = new V1ObjectMeta() { Name = NameSpace }
                });
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string LableToString(IDictionary<string, string> lableDict)
        {
            var labels = new List<string>();
            foreach (var key in lableDict)
            {
                labels.Add($"{key.Key}={key.Value}");
            }

            return string.Join(",", labels.ToArray());
        }

        private static JsonPatch CreatePathData(dynamic @new, dynamic old)
        {
            JsonDocument oldDoc = JsonSerializer.SerializeToDocument(old, serializerOptions);
            try
            {
                old.Data = @new.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                old.Spec = @new.Spec;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            old.Metadata.Labels = @new.Metadata.Labels;
            old.Metadata.Annotations = @new.Metadata.Annotations;
            JsonDocument expected = JsonSerializer.SerializeToDocument(old);
            return oldDoc.CreatePatch(expected);
        }
    }
}
