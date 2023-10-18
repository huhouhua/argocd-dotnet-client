using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using k8s;

namespace ArgoCD.Client.Test.Utilities
{
    internal class ArgoCDKubernetesFixture : IAsyncLifetime
    {
        private const string InstallYamlPath = "/k8s/core-install.yaml";
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
            var config =  KubernetesClientConfiguration.BuildConfigFromConfigFile(Environment.GetEnvironmentVariable("KUBECONFIG"));
            kubernetes = new Kubernetes(config);

           var objects =  await KubernetesYaml.LoadAllFromFileAsync($"{SolutionRootFolder}/{InstallYamlPath}").
                ConfigureAwait(false);

            foreach (object item in objects)
            {
               
            }
        }
    }
}
