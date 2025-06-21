using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Http.Serialization;
using ArgoCD.Client.Models.Session.Requests;
using ArgoCD.Client.Models.Session.Responses;
using ArgoCD.Client.Test.Utilities;
using FluentAssertions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

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
        public void InvalidToke()
        {
            Action action = () => new ArgoCDClient(DefaultHost, "HelloWorld");
            action.Should()
                .Throw<ArgumentException>()
                .WithMessage("Unsupported authentication token provide, please private an oauth or private token");
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

        [Trait("Category", "LinuxIntegration")]
        [Collection("ArgoCDKubernetesFixture")]
        public class Integration
        {
            [Fact]
            public async void CanLogin()
            {
                var sut = new ArgoCDClient(ArgoCDKubernetesFixture.ArgoCDHost,
                    httpMessageHandler: CreateHandler());
                var sessionTokenResponse =
                    await sut.LoginAsync(TestUserName, ArgoCDKubernetesFixture.Password);
                sessionTokenResponse.Should().NotBeNull();
                sessionTokenResponse.Token.Should().HaveLength(257);

                var currentSession = await sut.Session.GetCurrentUserInfoAsync();
                currentSession.Should().NotBeNull();
                currentSession.Username.Should().Be(TestUserName);
                currentSession.Iss.Should().Be(TestIss);
                currentSession.LoggedIn.Should().BeTrue();

                sut = new ArgoCDClient(ArgoCDKubernetesFixture.ArgoCDHost, sessionTokenResponse.Token, httpMessageHandler: CreateHandler());
                currentSession = await sut.Session.GetCurrentUserInfoAsync();
                currentSession.Username.Should().Be(TestUserName);

                var facadeSut = new DefaultArgoCDHttpFacade(ArgoCDKubernetesFixture.ArgoCDHost,JsonSerializer,
                    ArgoCDKubernetesFixture.Token,CreateHandler());

                currentSession = await facadeSut.GetAsync<UserInfo>("session/userinfo");
                currentSession.Username.Should().Be(TestUserName);
                sessionTokenResponse = await facadeSut.LoginAsync(new CreateSessionRequest()
                {
                    UserName = TestUserName,
                    Password = ArgoCDKubernetesFixture.Password,
                });

                currentSession = await facadeSut.GetAsync<UserInfo>("session/userinfo");
                currentSession.Username.Should().Be(TestUserName);

                facadeSut = new DefaultArgoCDHttpFacade(ArgoCDKubernetesFixture.ArgoCDHost, JsonSerializer,
                    sessionTokenResponse.Token,CreateHandler());
                currentSession = await facadeSut.GetAsync<UserInfo>("session/userinfo");
                currentSession.Username.Should().Be(TestUserName);
            }
        }
    }
}
