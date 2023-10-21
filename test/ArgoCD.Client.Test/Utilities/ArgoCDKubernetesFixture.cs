using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ArgoCD.Client.Internal.Utilities;
using Json.Patch;
using k8s;
using k8s.Models;

namespace ArgoCD.Client.Test.Utilities
{
    internal class ArgoCDKubernetesFixture : IAsyncLifetime
    {
        private static JsonSerializerOptions serializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
        private const string InstallFilePath = "/k8s/install.yaml";
        private const string kubeConfigFilePath = "/k8s/kubeconfig.yaml";
        private static readonly TemplateString SolutionRootFolder = "${PWD}/../../../../..";
        public static string Token { get; private set; }
        public static string ArgoCDHost { get; private set; }
        private IKubernetes kubernetes;

        public  async Task InitializeAsync()
        {
            await StartKubernetesAsync();
             
        }

        public Task DisposeAsync()
        {
            kubernetes?.Dispose();
            return Task.CompletedTask;

        }
        private async Task StartKubernetesAsync()
        {
            var config =  KubernetesClientConfiguration.BuildConfigFromConfigFile($"{SolutionRootFolder}/{kubeConfigFilePath}");
            kubernetes = new Kubernetes(config);

            var objects = await KubernetesYaml.LoadAllFromFileAsync($"{SolutionRootFolder}/{InstallFilePath}");
            await ApplyAsync(objects);
        }


        private async Task ApplyAsync(IList<object> objects)
        {
            foreach (object item in objects)
            {
                //namespace: argocd
                var kubernetesObj = (IKubernetesObject<V1ObjectMeta>)item;
                string @namespace = "default";
                string fieldSelector = $"metadata.name={kubernetesObj.Name()}";
                if (kubernetesObj.Namespace().IsNotNullOrEmpty())
                {
                    @namespace = kubernetesObj.Namespace();
                    fieldSelector = $"{fieldSelector},metadata.namespace={kubernetesObj.Namespace()}";
                }

                switch (kubernetesObj.Kind)
                {
                    case V1CustomResourceDefinition.KubeKind:
                        var newDefinition = (V1CustomResourceDefinition)item;

                        var definitionList = await kubernetes.ApiextensionsV1.ListCustomResourceDefinitionAsync(null, null, fieldSelector, null);
                        if (!definitionList.Items.Any())
                        {
                            _ = await kubernetes.ApiextensionsV1.CreateCustomResourceDefinitionAsync(newDefinition);
                        }
                        else
                        {
                            var oldDefinition = definitionList.Items.First();
                            _ = await kubernetes.ApiextensionsV1.PatchCustomResourceDefinitionAsync(new V1Patch(CreatePathData(newDefinition, oldDefinition), V1Patch.PatchType.JsonPatch), newDefinition.Name());
                        }
                        break;
                    case V1ServiceAccount.KubeKind:
                        var newServiceAccount = (V1ServiceAccount)item;

                        var serviceAccountList = await kubernetes.CoreV1.ListNamespacedServiceAccountAsync(@namespace, null, null, fieldSelector);
                        if (!serviceAccountList.Items.Any())
                        {
                            _ = await kubernetes.CoreV1.CreateNamespacedServiceAccountAsync(newServiceAccount, @namespace);
                        }
                        else
                        {
                            var oldServiceAccount = serviceAccountList.Items.First();
                            _ = await kubernetes.CoreV1.PatchNamespacedServiceAccountAsync(new V1Patch(CreatePathData(newServiceAccount, oldServiceAccount), V1Patch.PatchType.JsonPatch), oldServiceAccount.Name(), oldServiceAccount.Namespace());
                        }
                        break;
                    case V1Role.KubeKind:
                        var newRole = (V1Role)item;

                        var roleList = await kubernetes.RbacAuthorizationV1.ListNamespacedRoleAsync(@namespace, null, null, fieldSelector);
                        if (!roleList.Items.Any())
                        {
                            _ = await kubernetes.RbacAuthorizationV1.CreateNamespacedRoleAsync(newRole, @namespace);
                        }
                        else
                        {
                            var oldRole = roleList.Items.First();
                            _ = await kubernetes.RbacAuthorizationV1.PatchNamespacedRoleAsync(new V1Patch(CreatePathData(newRole, oldRole), V1Patch.PatchType.JsonPatch), oldRole.Name(), oldRole.Namespace());
                        }
                        break;
                    case V1ClusterRole.KubeKind:
                        var newClusterRole = (V1ClusterRole)item;

                        var clusterRoleList = await kubernetes.RbacAuthorizationV1.ListClusterRoleAsync(null, null, fieldSelector);
                        if (!clusterRoleList.Items.Any())
                        {
                            _ = await kubernetes.RbacAuthorizationV1.CreateClusterRoleAsync(newClusterRole);
                        }
                        else
                        {
                            var oldClusterRole = clusterRoleList.Items.First();
                            _ = await kubernetes.RbacAuthorizationV1.PatchClusterRoleAsync(new V1Patch(CreatePathData(newClusterRole, oldClusterRole), V1Patch.PatchType.JsonPatch), oldClusterRole.Name());
                        }
                        break;
                    case V1RoleBinding.KubeKind:
                        var newRoleBinding = (V1RoleBinding)item;

                        var roleBindingList = await kubernetes.RbacAuthorizationV1.ListRoleBindingForAllNamespacesAsync(null, null, fieldSelector);
                        if (!roleBindingList.Items.Any())
                        {
                            _ = await kubernetes.RbacAuthorizationV1.CreateNamespacedRoleBindingAsync(newRoleBinding, @namespace);
                        }
                        else
                        {
                            var oldRoleBinding = roleBindingList.Items.First();
                            _ = await kubernetes.RbacAuthorizationV1.PatchNamespacedRoleBindingAsync(new V1Patch(CreatePathData(newRoleBinding, oldRoleBinding), V1Patch.PatchType.JsonPatch), oldRoleBinding.Name(), oldRoleBinding.Namespace());
                        }
                        break;
                    case V1ClusterRoleBinding.KubeKind:
                        var newClusterRoleBinding = (V1ClusterRoleBinding)item;

                        var clusterRoleBindingList = await kubernetes.RbacAuthorizationV1.ListClusterRoleBindingAsync(null, null, fieldSelector);
                        if (!clusterRoleBindingList.Items.Any())
                        {
                            _ = await kubernetes.RbacAuthorizationV1.CreateClusterRoleBindingAsync(newClusterRoleBinding);
                        }
                        else
                        {
                            var oldClusterRoleBinding = clusterRoleBindingList.Items.First();
                            _ = await kubernetes.RbacAuthorizationV1.PatchClusterRoleBindingAsync(new V1Patch(CreatePathData(newClusterRoleBinding, oldClusterRoleBinding), V1Patch.PatchType.JsonPatch), oldClusterRoleBinding.Name());
                        }
                        break;
                    case V1ConfigMap.KubeKind:
                        var newConfigMap = (V1ConfigMap)item;

                        var configMapList = await kubernetes.CoreV1.ListConfigMapForAllNamespacesAsync(null, null, fieldSelector);
                        if (!configMapList.Items.Any())
                        {
                            _ = await kubernetes.CoreV1.CreateNamespacedConfigMapAsync(newConfigMap, @namespace);
                        }
                        else
                        {
                            var oldConfigMap = configMapList.Items.First();
                            _ = await kubernetes.CoreV1.PatchNamespacedConfigMapAsync(new V1Patch(CreatePathData(newConfigMap, oldConfigMap), V1Patch.PatchType.JsonPatch), oldConfigMap.Name(), oldConfigMap.Namespace());
                        }
                        break;
                    case V1Secret.KubeKind:
                        var newSecret = (V1Secret)item;
                        var secretList = await kubernetes.CoreV1.ListSecretForAllNamespacesAsync(null, null, fieldSelector);
                        if (!secretList.Items.Any())
                        {
                            _ = await kubernetes.CoreV1.CreateNamespacedSecretAsync(newSecret, @namespace);
                        }
                        else
                        {
                            var oldSecret = secretList.Items.First();
                            _ = await kubernetes.CoreV1.PatchNamespacedSecretAsync(new V1Patch(CreatePathData(newSecret, oldSecret), V1Patch.PatchType.JsonPatch), oldSecret.Name(), oldSecret.Namespace());
                        }
                        break;
                    case V1Service.KubeKind:
                        var newService = (V1Service)item;
                        var serviceList = await kubernetes.CoreV1.ListNamespacedServiceAsync(@namespace, null, null, fieldSelector);
                        if (!serviceList.Items.Any())
                        {
                            _ = await kubernetes.CoreV1.CreateNamespacedServiceAsync(newService, @namespace);
                        }
                        else
                        {
                            var oldService = serviceList.Items.First();
                            _ = await kubernetes.CoreV1.PatchNamespacedServiceAsync(new V1Patch(CreatePathData(newService, oldService), V1Patch.PatchType.JsonPatch), oldService.Name(), oldService.Namespace());
                        }
                        break;
                    case V1Deployment.KubeKind:
                        var newDeployment = (V1Deployment)item;
                        var deploymentList = await kubernetes.AppsV1.ListDeploymentForAllNamespacesAsync(null, null, fieldSelector);
                        if (!deploymentList.Items.Any())
                        {
                            _ = await kubernetes.AppsV1.CreateNamespacedDeploymentAsync(newDeployment, @namespace);
                        }
                        else
                        {
                            var oldDeployment = deploymentList.Items.First();
                            _ = await kubernetes.AppsV1.PatchNamespacedDeploymentAsync(new V1Patch(CreatePathData(newDeployment, oldDeployment), V1Patch.PatchType.JsonPatch), oldDeployment.Name(), oldDeployment.Namespace());
                        }
                        break;
                    case V1StatefulSet.KubeKind:
                        var newStatefulSet = (V1StatefulSet)item;
                        var statefulSetList = await kubernetes.AppsV1.ListStatefulSetForAllNamespacesAsync(null, null, fieldSelector);
                        if (!statefulSetList.Items.Any())
                        {
                            _ = await kubernetes.AppsV1.CreateNamespacedStatefulSetAsync(newStatefulSet, @namespace);
                        }
                        else
                        {
                            var oldStatefulSet = statefulSetList.Items.First();
                            _ = await kubernetes.AppsV1.PatchNamespacedStatefulSetAsync(new V1Patch(CreatePathData(newStatefulSet, newStatefulSet), V1Patch.PatchType.JsonPatch), oldStatefulSet.Name(), oldStatefulSet.Namespace());
                        }
                        break;
                    case V1NetworkPolicy.KubeKind:
                        var newNetworkPolicy = (V1NetworkPolicy)item;
                        var networkPolicyList = await kubernetes.NetworkingV1.ListNetworkPolicyForAllNamespacesAsync(null, null, fieldSelector);
                        if (!networkPolicyList.Items.Any())
                        {
                            _ = await kubernetes.NetworkingV1.CreateNamespacedNetworkPolicyAsync(newNetworkPolicy, @namespace);
                        }
                        else
                        {
                            var oldNetworkPolicy = networkPolicyList.Items.First();
                            _ = await kubernetes.NetworkingV1.PatchNamespacedNetworkPolicyAsync(new V1Patch(CreatePathData(newNetworkPolicy, newNetworkPolicy), V1Patch.PatchType.JsonPatch), oldNetworkPolicy.Name(), oldNetworkPolicy.Namespace());
                        }
                        break;
                    default:
                        throw new NotImplementedException($"{kubernetesObj.Kind} not implemented!");
                }
            }

        }

        private static string LableToString(IDictionary<string,string> lableDict)
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
