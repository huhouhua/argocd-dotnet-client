using System;
using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Models.Session.Responses;
using ArgoCD.Client.Test.Utilities;
using FluentAssertions;
using Xunit.Abstractions;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class SessionClientTest
{
    private readonly ISessionClient _client = new SessionClient(ArgoCDApiHelper.GetFacade());
    private readonly ITestOutputHelper _testOutputHelper;

    public SessionClientTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    [Fact]
    public async Task CurrentUserSessionCanBeRetrieved()
    {
        _testOutputHelper.WriteLine("Run CurrentUserSessionCanBeRetrieved----------------------------------------------------------->>> start");
        var userInfo = await _client.GetCurrentUserInfoAsync();
        _testOutputHelper.WriteLine("Run CurrentUserSessionCanBeRetrieved----------------------------------------------------------->>>  end");

        userInfo.LoggedIn.Should().BeTrue();
        userInfo.Username.Should().Be("admin");
        userInfo.Iss.Should().Be("argocd");
    }

    // [Fact]
    // public async Task DeleteSessionCanBeRetrieved()
    // {
    //    var action = async () => await _client.DeleteCurrentSessionAsync();
    //     await action.Should().NotThrowAsync();
    // }
}
