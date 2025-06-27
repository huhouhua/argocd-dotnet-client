using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Builders;
using FluentAssertions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class ClusterClientTest : IAsyncLifetime
{
    private readonly IClusterClient _client = new ClusterClient(GetFacade(),
        new ClusterQueryBuilder(),
        new ClusterUpdateBuilder(),
        new UpsertBuilder());


    public Task InitializeAsync() => CleanupClusters();

    public Task DisposeAsync() => CleanupClusters();

    private async Task CleanupClusters()
    {
        await Task.CompletedTask;
    }
}
