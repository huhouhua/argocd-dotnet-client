using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Impl;
using FluentAssertions;

namespace ArgoCD.Client.Test
{
    public class ArgoCDClientTest
    {
        private const string DefaultHost = "https://localhost:30188/api/v1/";

        [Theory]
        [InlineData(DefaultHost)]
        [InlineData("https://localhost:30188/api/v1")]
        [InlineData("https://localhost:30188/")]
        [InlineData("https://localhost:30188")]
        public void ArgoCDClientCanBeConstructed(string hostUrl)
        {
            var sut = new ArgoCDClient(hostUrl);
            sut.HostUrl.Should().Be("https://localhost:30188/api/v1/");
        }

        [Fact]
        public void CheckClients()
        {
            var sut = new ArgoCDClient(DefaultHost);
            sut.Version.Should().BeAssignableTo<VersionClient>();
            sut.Settings.Should().BeAssignableTo<SettingsClient>();
            sut.Notification.Should().BeAssignableTo<NotificationClient>();
            sut.Session.Should().BeAssignableTo<SessionClient>();
            sut.Account.Should().BeAssignableTo<AccountClient>();
            sut.Certificate.Should().BeAssignableTo<CertificateClient>();
            sut.GPKKey.Should().BeAssignableTo<GPKKeyClient>();
            sut.RepoCreds.Should().BeAssignableTo<RepoCredsClient>();
            sut.Cluster.Should().BeAssignableTo<ClusterClient>();
            sut.Repository.Should().BeAssignableTo<RepositoryClient>();
            sut.Project.Should().BeAssignableTo<ProjectClient>();
            sut.ApplicationSet.Should().BeAssignableTo<ApplicationSetClient>();
            sut.Application.Should().BeAssignableTo<ApplicationClient>();
        }
    }
}
