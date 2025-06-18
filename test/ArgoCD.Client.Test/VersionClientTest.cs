using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Test.Utilities;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace ArgoCD.Client.Test
{
    [Trait("Category", "LinuxIntegration")]
    [Collection("ArgoCDKubernetesFixture")]
    public class VersionClientTest
    {
        private readonly IVersionClient _client = new VersionClient(ArgoCDApiHelper.GetFacadeWithNotVersion());

        [Fact]
        public async Task GetVersionInfoTest()
        {
            var file = await _client.GetVersionAsync();
            file.Should().NotBeNull();
        }
    }
}
