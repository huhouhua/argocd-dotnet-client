using System.IO;
using System.Text;
using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Http.Serialization;
using ArgoCD.Client.Models.Settings.Responses;
using ArgoCD.Client.Test.Utilities;
using FluentAssertions;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class SettingClientTest
{
    private readonly ISettingsClient _client = new SettingsClient(ArgoCDApiHelper.GetFacade());
    private readonly RequestsJsonSerializer _jsonSerializer = new();

    [Fact]
    public async Task PluginsCanBeRetrieved()
    {
        var plugins = await _client.GetPluginsAsync();
        plugins.Should().NotBeNull();
        plugins.Should().BeEquivalentTo(new ClusterSettingsPlugins());
    }

    [Fact]
    public async Task SettingsCanBeRetrieved()
    {
        string clusterSettings =
            await File.ReadAllTextAsync(Path.Combine(ArgoCDApiHelper.TestDataBasePath, "settings.json"), Encoding.UTF8);
        var expected = _jsonSerializer.Deserialize<ClusterSettings>(clusterSettings);
        var actual = await _client.GetSettingsAsync();
        actual.Should().BeEquivalentTo(expected);
    }
}
