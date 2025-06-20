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

    [Fact]
    public async Task CurrentUserSessionCanBeRetrieved()
    {
        var userInfo = await _client.GetCurrentUserInfoAsync();
        userInfo.LoggedIn.Should().BeTrue();
        userInfo.Username.Should().Be(ArgoCDApiHelper.TestUserName);
        userInfo.Iss.Should().Be(ArgoCDApiHelper.TestIss);
    }

    [Fact]
    public async Task DeleteSessionCanBeRetrieved()
    {
       var action = async () => await _client.DeleteCurrentSessionAsync();
        await action.Should().NotThrowAsync();
    }
}
