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
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IVersionClient _client = new VersionClient(ArgoCDApiHelper.GetFacadeWithNotVersion());

        public VersionClientTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task GetVersionInfoTest()
        {
            _testOutputHelper.WriteLine("Run GetVersionInfoTest----------------------------------------------------------->>> start");
            var file = await _client.GetVersionAsync();
            _testOutputHelper.WriteLine("Run GetVersionInfoTest----------------------------------------------------------->>>  end");
            file.Should().NotBeNull();
        }
    }
}
