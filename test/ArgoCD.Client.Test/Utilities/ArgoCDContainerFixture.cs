using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArgoCD.Client.Test.Utilities
{
    internal class ArgoCDContainerFixture : IAsyncLifetime
    {
        public Task DisposeAsync()
        {
            return Task.CompletedTask;

        }
        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
