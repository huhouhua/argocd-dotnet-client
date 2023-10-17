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
        public static string Token { get; private set; }
        public static string ArgoCDHost { get; private set; }
        private  Kubernetes kubernetes;


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
         
             await Task.CompletedTask;
        }
    }
}
