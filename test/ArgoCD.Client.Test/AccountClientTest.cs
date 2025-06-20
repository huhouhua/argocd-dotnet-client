using System.IO;
using System.Text;
using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Http.Serialization;
using ArgoCD.Client.Models.Settings.Responses;
using ArgoCD.Client.Test.Utilities;
using FluentAssertions;

namespace ArgoCD.Client.Test;

// [Trait("Category", "LinuxIntegration")]
// [Collection("ArgoCDKubernetesFixture")]
public class AccountClientTest
{
    // private readonly IAccountClient _client = new AccountClient(ArgoCDApiHelper.GetFacade());

    private readonly RequestsJsonSerializer _jsonSerializer = new();

    [Fact]
    public async Task Test()
    {
        string data=  await File.ReadAllTextAsync(Path.Combine(ArgoCDApiHelper.TestDataBasePath,"settings.json"),Encoding.UTF8);
        var clusterSettings = _jsonSerializer.Deserialize<ClusterSettings>(data);
        clusterSettings.Should().NotBeNull();
    }

    // [Fact]
    // public async Task PluginsCanBeRetrieved()
    // {
    //     var plugins = await _client.GetAccountListAsync();
    //     plugins.Should().NotBeNull();
    //     plugins.Should().Be(new ClusterSettingsPlugins(){ Plugins=null });
    // }
    //
    // [Fact]
    // public async Task SettingsCanBeRetrieved()
    // {
    //     var expect = new ClusterSettings()
    //     {
    //         AppLabelKey = "app.kubernetes.io/instance",
    //         ResourceOverrides = new V1alpha1ResourceOverride()
    //         {
    //
    //         }
    //     };
    //     var actual =  await _client.GetSettingsAsync();
    //     actual.Should().Be(expect);
    // }
}
