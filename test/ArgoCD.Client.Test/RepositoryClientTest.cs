using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Builders;
using FluentAssertions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class RepositoryClientTest : IAsyncLifetime
{
    private readonly IRepositoryClient _client = new RepositoryClient(GetFacade(),
        new RepositoryQueryBuilder(),
        new CreateRepositoryBuilder(),
        new RepositoryRefreshBuilder(),
        new RepositoryQueryAppBuilder(),
        new ValidateAccessBuilder());

    public Task InitializeAsync() => CleanupRepositorys();

    public Task DisposeAsync() => CleanupRepositorys();

    private async Task CleanupRepositorys()
    {
        await Task.CompletedTask;
    }
}
