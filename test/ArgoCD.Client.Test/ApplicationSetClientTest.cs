using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Builders;
using FluentAssertions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class ApplicationSetClientTest : IAsyncLifetime
{
    private readonly IApplicationSetClient _client = new ApplicationSetClient(GetFacade(),
        new UpsertBuilder(),
        new ApplicationSetQueryBuilder(),
        new ApplicationSetListQueryBuilder());


    public Task InitializeAsync() => CleanupApplicationSets();

    public Task DisposeAsync() => CleanupApplicationSets();

    private async Task CleanupApplicationSets()
    {
        await Task.CompletedTask;
    }
}
