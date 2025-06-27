using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Builders;
using ArgoCD.Client.Models.Certificate.Reponses;
using ArgoCD.Client.Models.Certificate.Requests;
using ArgoCD.Client.Models.GPKKey.Requests;
using FluentAssertions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class CertificateClientTest:IAsyncLifetime
{
    private readonly ICertificateClient _client = new CertificateClient(GetFacade(),
        new UpsertBuilder(),
        new CertificateQueryBuilder(),
        new CertificateDeleteBuilder());

    private List<V1alpha1RepositoryCertificate> CertificatesToClean { get; } = new();


    [Fact]
    public async Task ListCertificatesRetrieved()
    {
        var certificateList = await _client.GetListAsync((opt) =>
        {
            opt.HostNamePattern = TestHostNamePattern;
            opt.CertType = TestCertType;

        });
        certificateList.Should().NotBeNull();
        certificateList.Items.Should().Contain(x => x.ServerName == TestHostNamePattern);
    }


    [Theory]
    [MemberData(nameof(TestCertificatesCases))]
    public async Task CertificateCreate(CreateRepositoryCertificateRequest createRequest, bool wantErr=false,bool upsert =true)
    {
        RepositoryCertificateList certificateList = null;
        var action = async () => certificateList= await _client.CreateRepositoryCertificateAsync(createRequest, (opt) =>
        {
            opt.Upsert = upsert;
        } );
        if (wantErr)
        {
            await action.Should().ThrowAsync<ArgoCDException>();
            return;
        }
        await action.Should().NotThrowAsync();
        certificateList.Should().NotBeNull();
        certificateList.Items.Should().BeEquivalentTo(createRequest.Items);
        CertificatesToClean.AddRange(certificateList.Items);
    }

    [Fact]
    public async Task CertificateCreateWithTLS()
    {
        string tlsValidMultiCert =  await File.ReadAllTextAsync(Path.Combine(TestDataBasePath, "testTLSValidMultiCert.txt"), Encoding.UTF8);

        var createRequest = new CreateRepositoryCertificateRequest()
        {
            Items = new V1alpha1RepositoryCertificate[]
            {
                new V1alpha1RepositoryCertificate()
                {
                    ServerName = "foo.example.com",
                    CertType = "https",
                    CertData = Convert.ToBase64String(Encoding.UTF8.GetBytes(tlsValidMultiCert))
                }
            },
        };
         var certificateList=  await _client.CreateRepositoryCertificateAsync(createRequest, (opt) =>
        {
            opt.Upsert = true;
        });
        certificateList.Should().NotBeNull();
        certificateList.Items.Should().HaveCount(2);
        CertificatesToClean.AddRange(certificateList.Items);
    }

    [Fact]
    public async Task CreateCertificateCanBeDelete()
    {
        byte[] ed25519=  Encoding.UTF8.GetBytes("AAAAC3NzaC1lZDI1NTE5AAAAIAYynaOD/wo8xg3YN4BbdrEozPZ5TvQ3R/qxLzy9gMr8");
        var createRequest = new CreateRepositoryCertificateRequest()
        {
                Items = new V1alpha1RepositoryCertificate[]
                {
                    new V1alpha1RepositoryCertificate()
                    {
                        ServerName = "[argocd-e2e-server]:2222",
                        CertType      = "ssh",
                        CertSubType= "ssh-ed25519",
                        CertInfo = "XBF4aklGoVMIsbFXHGwlR55PEhAC4JS9fAgz2zDzuJw",
                        CertData = Convert.ToBase64String(ed25519)
                    }
                }
        };
        var certificateList = await _client.CreateRepositoryCertificateAsync(createRequest, (opt) =>
        {
            opt.Upsert = true;
        });
        certificateList.Should().NotBeNull();
        var certificate= certificateList.Items.Should().ContainSingle(x=>x.ServerName==createRequest.Items[0].ServerName).Which;
        CertificatesToClean.Add(certificate);

       var action = async () => await _client.DeleteRepositoryCertificateAsync((opt) =>
                  {
                      opt.CertType = certificate.CertType;
                      opt.CertSubType = certificate.CertSubType;
                      opt.HostNamePattern = certificate.ServerName;
                  });
        await action.Should().NotThrowAsync();
    }

    public static IEnumerable<object[]> TestCertificatesCases()
    {
        byte[] sshRsa = Encoding.UTF8.GetBytes(
            "AAAAB3NzaC1yc2EAAAADAQABAAABAQDcBar/5tNRUw2MIeY2wzLllG4Opt9h4i/8dRnyxCdDQb30ioH0ervPFRoR1ZJVF/jVI4waHZJ74m/" +
            "70OxwhSBVA/oPFtRl6C+at2BTgj5uLb9TqVoLSP/VT5M31ohWwBuIsYoQrbwpxwXpgLAQ65M+ghegW3SALnyxEuCWEd/mqCOmwcXWPKNDM32AB3OU/" +
            "qhW3ID66aIo26LJ8OQ7yZSv/2xWWGiVbRShNjDLqGfkbk5+R+vpVdaIhJn22nX5d1i/modeBepJN8eo4gO7p0vkmCTFxq6aUrRtPPs2h7z61GsYG7miWn4hjjeGVrT1Xv0BTrnuWHxcJU1bSmKCx4rV");
        byte[] ecdsa= Encoding.UTF8.GetBytes(
            "AAAAE2VjZHNhLXNoYTItbmlzdHAyNTYAAAAIbmlzdHAyNTYAAABBBCk3mMbdKoeHKJvXHoPAHa0D8ZZnuGbNN0iM9Lo0o52V7vErpBmKb0qkmGajVqR7XvflAHhkmSfIDXLz4/Pxp4E=");
        byte[] ed25519=  Encoding.UTF8.GetBytes("AAAAC3NzaC1lZDI1NTE5AAAAIAYynaOD/wo8xg3YN4BbdrEozPZ5TvQ3R/qxLzy9gMr8");

        string tlsValidSingleCert = File.ReadAllText(Path.Combine(TestDataBasePath, "testTLSInvalidSingleCert.txt"), Encoding.UTF8);
        yield return new object[]
        {
            new CreateRepositoryCertificateRequest()
            {
                Items = new V1alpha1RepositoryCertificate[]
                {
                    new V1alpha1RepositoryCertificate()
                    {
                        ServerName = "[argocd-e2e-server]:2222",
                        CertType      = "ssh",
                        CertSubType= "ssh-rsa",
                        CertInfo = "MC/XUrNjw3tX0KhxJFtUcEfUfiVYXMOE3DhdXDGZBSI",
                        CertData = Convert.ToBase64String(sshRsa)
                    },
                    new V1alpha1RepositoryCertificate()
                    {
                        ServerName = "[argocd-e2e-server]:2222",
                        CertType      = "ssh",
                        CertSubType= "ecdsa-sha2-nistp256",
                        CertInfo = "v1f2WPaJhHf1K/sWuQ61MIsvwnrPJsyHjnwn2B2UyiM",
                        CertData = Convert.ToBase64String(ecdsa)
                    },
                    new V1alpha1RepositoryCertificate()
                    {
                        ServerName = "[argocd-e2e-server]:2222",
                        CertType      = "ssh",
                        CertSubType= "ssh-ed25519",
                        CertInfo = "XBF4aklGoVMIsbFXHGwlR55PEhAC4JS9fAgz2zDzuJw",
                        CertData = Convert.ToBase64String(ed25519)
                    }
                },
            },
        };
        yield return new object[]
        {
            new CreateRepositoryCertificateRequest()
            {
                Items = new V1alpha1RepositoryCertificate[]
                {
                    new V1alpha1RepositoryCertificate()
                    {
                        ServerName = "foo.example.com",
                        CertType      = "https",
                        CertData = Convert.ToBase64String(Encoding.UTF8.GetBytes(tlsValidSingleCert))
                    }
                },
            },
            true,
            false,
        };

    }

    public Task InitializeAsync() => CleanupCertificates();

    public Task DisposeAsync() => CleanupCertificates();

    private async Task CleanupCertificates()
    {
        foreach (var certificate in CertificatesToClean)
            try
            {
                await _client.DeleteRepositoryCertificateAsync((opt) =>
                {
                    opt.CertType = certificate.CertType;
                    opt.HostNamePattern = certificate.ServerName;
                    opt.CertSubType = certificate.CertSubType;
                });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Clear test data .... skipping exceptions :{e.Message}");
            }
    }

}
