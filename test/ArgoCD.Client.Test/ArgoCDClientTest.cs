using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Impl;

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
            Assert.Equal("https://localhost:30188/api/v1/", sut.HostUrl);
        }

        [Fact]
        public void CheckClients()
        {
            var sut = new ArgoCDClient(DefaultHost);
            Assert.IsAssignableFrom<VersionClient>(sut.Version);
            Assert.IsAssignableFrom<SettingsClient>(sut.Settings);
            Assert.IsAssignableFrom<NotificationClient>(sut.Notification);
            Assert.IsAssignableFrom<SessionClient>(sut.Session);
            Assert.IsAssignableFrom<AccountClient>(sut.Account);
            Assert.IsAssignableFrom<CertificateClient>(sut.Certificate);
            Assert.IsAssignableFrom<GPKKeyClient>(sut.GPKKey);
            Assert.IsAssignableFrom<RepoCredsClient>(sut.RepoCreds);
            Assert.IsAssignableFrom<ClusterClient>(sut.Cluster);
            Assert.IsAssignableFrom<RepositoryClient>(sut.Repository);
            Assert.IsAssignableFrom<ProjectClient>(sut.Project);
            Assert.IsAssignableFrom<ApplicationSetClient>(sut.ApplicationSet);
            Assert.IsAssignableFrom<ApplicationClient>(sut.Application);
        }


    }
}
