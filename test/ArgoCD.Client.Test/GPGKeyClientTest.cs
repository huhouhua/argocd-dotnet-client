using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Builders;
using ArgoCD.Client.Models.Account.Requests;
using ArgoCD.Client.Models.GPKKey.Requests;
using ArgoCD.Client.Models.GPKKey.Responses;
using FluentAssertions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class GPGKeyClientTest : IAsyncLifetime
{
    private readonly IGPGKeyClient _client = new GPGKeyClient(GetFacade(),
        new UpsertBuilder(),
        new GPGKeyDeleteBuilder(),
        new GPGListQueryBuilder());

    private List<string> KeyIdsToClean { get; } = new();


    [Fact]
    public async Task GPGKeyCanBeRetrievedByKeyId()
    {
        var gnuPgPublicKey = await _client.GetAsync(TestRsaKeyId);
        gnuPgPublicKey.Should().NotBeNull();
        gnuPgPublicKey.KeyID.Should().Be(TestRsaKeyId);
        gnuPgPublicKey.Fingerprint.Should().Be(TestFingerprint);
        gnuPgPublicKey.SubType.Should().Be("rsa2048");
        gnuPgPublicKey.Owner.Should().Be(TestOwner);
        gnuPgPublicKey.Trust.Should().Be(TestTrust);
        gnuPgPublicKey.KeyData.Should().NotBeEmpty();
    }

    [Fact]
    public async Task ListKeyIdRetrievedByKeyId()
    {
        var gnuPgPublicKey = await _client.GetListAsync((opt) =>
        {
            opt.KeyID = TestRsaKeyId;
        });
        gnuPgPublicKey.Should().NotBeNull();
        var publicKeyInfo = gnuPgPublicKey.Items.Should().ContainSingle(x => x.KeyID == TestRsaKeyId).Which;

        publicKeyInfo.KeyID.Should().Be(TestRsaKeyId);
        publicKeyInfo.Fingerprint.Should().Be(TestFingerprint);
        publicKeyInfo.SubType.Should().Be("rsa2048");
        publicKeyInfo.Owner.Should().Be(TestOwner);
        publicKeyInfo.Trust.Should().Be(TestTrust);
        publicKeyInfo.KeyData.Should().NotBeEmpty();
    }

    [Theory]
    [MemberData(nameof(GPGKeyData))]
    public async Task GPGKeyCreate(CreateGPGKeyRequest request,bool wantNull=false)
    {
        var gnuPgPublicKey = await _client.CreateGPKKeyAsync(request, (opt) =>
        {
            opt.Upsert = true;
        });
        gnuPgPublicKey.Should().NotBeNull();

        if (wantNull)
        {
            gnuPgPublicKey.Created.Items.Should().BeNull();
            return;
        }
        var publicKeyInfo = gnuPgPublicKey.Created.Items.Should().ContainSingle().Which;
        publicKeyInfo.Should().Match<V1alpha1GnuPGPublicKey>(p =>
            p.Fingerprint == request.Fingerprint &&
            p.KeyID == request.KeyID &&
            p.Owner == request.Owner &&
            !string.IsNullOrWhiteSpace(p.KeyData) &&
            p.SubType == request.SubType &&
            p.Trust == request.Trust);
        KeyIdsToClean.Add(request.KeyID);
    }

    [Fact]
    public async Task CreateGPGKeyCanBeDelete()
    {
        string keyDataWithEcdsa = File.ReadAllText(Path.Combine(TestDataBasePath, "testkey_ecdsa.txt"), Encoding.UTF8);
        var createRequest = new CreateGPGKeyRequest()
        {
            Fingerprint = "F30DB5A48B2107CAE61999026F8ECD6C1E8368C0",
            KeyID = "6F8ECD6C1E8368C0",
            KeyData = keyDataWithEcdsa,
            Owner = TestOwner,
            SubType = "nistp256",
            Trust = TestTrust
        };
        var gnuPgPublicKey = await _client.CreateGPKKeyAsync(createRequest, (opt) =>
        {
            opt.Upsert = true;
        });
        gnuPgPublicKey.Should().NotBeNull();
        gnuPgPublicKey.Created.Items.Should().ContainSingle().Which.KeyID.Should().Be(createRequest.KeyID);
        KeyIdsToClean.Add(createRequest.KeyID);

        var action = async () => await _client.DeleteGPKKeyAsync((opt) =>
        {
            opt.KeyID = createRequest.KeyID;
        });
        await action.Should().NotThrowAsync();
    }


    public static IEnumerable<object[]> GPGKeyData()
    {
        string keyDataWithRsa = File.ReadAllText(Path.Combine(TestDataBasePath, "testKey_rsa.txt"), Encoding.UTF8);
        string keyDataWithEcdsa = File.ReadAllText(Path.Combine(TestDataBasePath, "testkey_ecdsa.txt"), Encoding.UTF8);
        string keyDataWithEddsa = File.ReadAllText(Path.Combine(TestDataBasePath, "testkey_eddsa.txt"), Encoding.UTF8);

        yield return new object[] { new CreateGPGKeyRequest()
        {
            Fingerprint = TestFingerprint,
            KeyID = TestRsaKeyId,
            KeyData = keyDataWithRsa,
            Owner = TestOwner,
            SubType = "rsa2048",
            Trust = TestTrust,
        },true};
        yield return new object[] { new CreateGPGKeyRequest()
        {
            Fingerprint = "F30DB5A48B2107CAE61999026F8ECD6C1E8368C0",
            KeyID = "6F8ECD6C1E8368C0",
            KeyData = keyDataWithEcdsa,
            Owner = TestOwner,
            SubType = "nistp256",
            Trust = TestTrust,
        } };
        yield return new object[] { new CreateGPGKeyRequest()
        {
            Fingerprint = "0197A057E5D5834263F085BE05BBE32398D8E1CA",
            KeyID = "05BBE32398D8E1CA",
            KeyData = keyDataWithEddsa,
            Owner = TestOwner,
            SubType = "ed25519",
            Trust = TestTrust,
        } };
    }

    public Task InitializeAsync() => CleanupGPGKeyIds();

    public Task DisposeAsync() => CleanupGPGKeyIds();

    private async Task CleanupGPGKeyIds()
    {
        foreach (string id in KeyIdsToClean)
            try
            {
                await _client.DeleteGPKKeyAsync((opt) =>
                {
                    opt.KeyID = id;
                });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Clear test data .... skipping exceptions :{e.Message}");
            }
    }
}
