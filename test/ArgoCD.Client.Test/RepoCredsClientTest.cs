using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Builders;
using FluentAssertions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class RepoCredsClientTest : IAsyncLifetime
{
    private readonly IRepoCredsClient _client = new RepoCredsClient(GetFacade(),
        new RepoCredsListQueryBuilder(),
        new UpsertBuilder());


    public Task InitializeAsync() => CleanupRepoCreds();

    public Task DisposeAsync() => CleanupRepoCreds();

    private async Task CleanupRepoCreds()
    {
        await Task.CompletedTask;
    }
}
