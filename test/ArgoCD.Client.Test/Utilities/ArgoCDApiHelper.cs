using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Http.Serialization;

namespace ArgoCD.Client.Test.Utilities
{
    internal static class ArgoCDApiHelper
    {
        public const string TestUserNameWithAdmin = "admin";

        public const string TestUserName = "test";

        public const string Test2UserName = "test2";

        public const string Test3UserName = "test3";

        public const string TestIss = "argocd";

        public const string TestHostNamePattern = "github.com";

        public const string TestCertType = "ssh";

        public const string TestRsaKeyId = "9DC5CCDDE4372239";

        public const string TestFingerprint = "F6B8C8218D43BBC6F4AE9CA89DC5CCDDE4372239";

        public const string TestOwner = "ArgoCD Test <test@example.com>";

        public const string TestTrust = "expired";

        public static string TestDataBasePath = Path.Combine(Directory.GetCurrentDirectory(), "TestDatas");

        public static RequestsJsonSerializer JsonSerializer = new();

        public static HttpClientHandler CreateHandler() => new()
        {
            ServerCertificateCustomValidationCallback = (msg, cert, chain, errors) => true
        };

        public static IArgoCDHttpFacade GetFacadeWithUnauthorized() =>
            new DefaultArgoCDHttpFacade(() =>
            {
                return new HttpClient(CreateHandler()) { BaseAddress = new Uri(ArgoCDKubernetesFixture.ArgoCDHost), };
            }, JsonSerializer);


        public static IArgoCDHttpFacade GetFacade() =>
            new DefaultArgoCDHttpFacade(
                () => new(CreateHandler())
                {
                    BaseAddress = new Uri(ArgoCDKubernetesFixture.ArgoCDHost),
                    DefaultRequestHeaders =
                    {
                        Authorization = new AuthenticationHeaderValue("Bearer", ArgoCDKubernetesFixture.Token),
                    }
                }, JsonSerializer);

        public static IArgoCDHttpFacade GetFacadeWithNotVersion() =>
            new DefaultArgoCDHttpFacade(
                () => new(CreateHandler())
                {
                    BaseAddress =
                        new Uri(ArgoCDKubernetesFixture.ArgoCDHost.TrimEnd(new[] { '/', 'v', '1', '/' }) + "/"),
                    DefaultRequestHeaders =
                    {
                        Authorization = new AuthenticationHeaderValue("Bearer", ArgoCDKubernetesFixture.Token),
                    }
                }, JsonSerializer);
    }
}
