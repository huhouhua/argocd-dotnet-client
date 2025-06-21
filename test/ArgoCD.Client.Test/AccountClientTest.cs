using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Http.Serialization;
using ArgoCD.Client.Models.Account.Requests;
using ArgoCD.Client.Models.Settings.Responses;
using ArgoCD.Client.Test.Utilities;
using FluentAssertions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class AccountClientTest : IAsyncLifetime
{
    private readonly IAccountClient _client = new AccountClient(GetFacade());
    private List<string> TokenIdsToClean { get; } = new();

    [Fact]
    public async Task AccountRetrieved()
    {
        var account = await _client.GetAccountAsync(TestUserNameWithAdmin);
        account.Should().NotBeNull();
        account.Name.Should().Be(TestUserNameWithAdmin);
        account.Enabled.Should().BeTrue();
        account.Capabilities.Should().BeEquivalentTo(new[] { "login", "apiKey" });
    }

    [Fact]
    public async Task ListAccountRetrieved()
    {
        var accountList = await _client.GetAccountListAsync();
        accountList.Should().NotBeNull();
        var which = accountList.Items.Should().ContainSingle(x => x.Name == TestUserNameWithAdmin).Which;
        which.Enabled.Should().BeTrue();
        which.Capabilities.Should().BeEquivalentTo(new[] { "login", "apiKey" });
    }

    [Fact]
    public async Task AccountCreate()
    {
        var createRequest = new CreateAccountTokenRequest()
        {
            ExpiresIn = 3600, Id = Guid.NewGuid().ToString(), Name = TestUserNameWithAdmin,
        };
        var account = await _client.CreateAccountAsync(createRequest);
        account.Should().NotBeNull();
        account.Token.Should().HaveLength(259);
        TokenIdsToClean.Add(createRequest.Id);
    }

    [Fact]
    public async Task CreateAccountCanBeDelete()
    {
        var createRequest = new CreateAccountTokenRequest()
        {
            ExpiresIn = 3600, Id = Guid.NewGuid().ToString(), Name = TestUserNameWithAdmin,
        };
        var account = await _client.CreateAccountAsync(createRequest);
        account.Should().NotBeNull();
        account.Token.Should().HaveLength(259);
        TokenIdsToClean.Add(createRequest.Id);

        var action = async () => await _client.DeleteAccountAsync(TestUserNameWithAdmin, createRequest.Id);
        await action.Should().NotThrowAsync();

        var testAccount = await _client.GetAccountAsync(TestUserNameWithAdmin);
        testAccount.Should().NotBeNull();
        testAccount.Name.Should().Be(TestUserNameWithAdmin);
        testAccount.Tokens.Should().ContainSingle().Which.Id.Should().NotBe(createRequest.Id);
    }

    [Fact]
    public async Task UpdateAccountPassword()
    {
        var updateRequest = new UpdateAccountPasswordRequest()
        {
            Name = TestUserName,
            CurrentPassword = ArgoCDKubernetesFixture.Password,
            NewPassword = Guid.NewGuid().ToString("N").Substring(0, 16),
        };
        var action = async () => await _client.UpdateAccountPasswordAsync(updateRequest);
        await action.Should().NotThrowAsync();
    }

    [Theory]
    [MemberData(nameof(InitPermissionData))]
    public async Task CheckAccountCanBePermission(string resource, string action, string subresource,string wantValue)
    {
        var  actual = await  _client.CheckAccountPermissionAsync(resource, action, subresource);
        actual.Should().NotBeNull();
        actual.Value.Should().Be(wantValue);
    }

    public static IEnumerable<object[]> InitPermissionData()
    {
        string[] resources = { "applications", "clusters", "projects", "repositories", "accounts" };
        string[] actions = { "get", "create", "update", "delete" };
        string[] subresources = {"status", "logs" };

        foreach (string resource in resources)
        {
            foreach (string action in actions)
            {
                foreach (string subresource in subresources)
                {
                    yield return new object[] { resource, action, subresource, "yes" };
                }
            }
        }
    }

    public Task InitializeAsync() => CleanupAccounts();

    public Task DisposeAsync() => CleanupAccounts();

    private async Task CleanupAccounts()
    {
        foreach (string id in TokenIdsToClean)
            try
            {
                await _client.DeleteAccountAsync(TestUserNameWithAdmin, id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Clear test data, skipping exceptions :{e.Message}");
            }
    }
}
