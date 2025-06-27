using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Builders;
using FluentAssertions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class ApplicationClientTest : IAsyncLifetime
{
    private readonly IApplicationClient _client = new ApplicationClient(GetFacade(),
        new ApplicationListQueryBuilder(),
        new ApplicationQueryBuilder(),
        new ApplicationCreateOrUpdateBuilder(),
        new ApplicationDeleteBuilder(),
        new ResourcesQueryBuilder(),
        new ApplicationEventQueryBuilder(),
        new ApplicationLinksQueryBuilder(),
        new ApplicationLogQueryBuilder(),
        new ApplicationManifestsQueryBuilder(),
        new TerminateOperationBuilder(),
        new ApplicationResourceQueryBuilder(),
        new ApplicationResourceCreateBuilder(),
        new ApplicationResourceDeleteBuilder(),
        new ApplicationDetailsQueryBuilder(),
        new ApplicationUpdateSpecBuilder(),
        new ApplicationWatchQueryBuilder());


    public Task InitializeAsync() => CleanupApplications();

    public Task DisposeAsync() => CleanupApplications();

    private async Task CleanupApplications()
    {
        await Task.CompletedTask;
    }
}
