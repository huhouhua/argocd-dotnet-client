using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Builders;
using FluentAssertions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class ProjectClientTest : IAsyncLifetime
{
    private readonly IProjectClient _client = new ProjectClient(GetFacade(),
        new AppProjectQueryBuilder(),
        new ProjectTokenDeleteBuilder());


    public Task InitializeAsync() => CleanupProjects();

    public Task DisposeAsync() => CleanupProjects();

    private async Task CleanupProjects()
    {
         await Task.CompletedTask;
    }
}
