using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test
{
    [Trait("Category", "LinuxIntegration")]
    [Collection("ArgoCDContainerFixture")]
    public class VersionClientTest
    {
        private readonly IVersionClient _client = new VersionClient(GetFacadeWithUnauthorized());

        [Fact]
        public async Task GetVersionInfoTest()
        {
            var file = await _client.GetVersionAsync().
                ConfigureAwait(false);

        }
    }
}
