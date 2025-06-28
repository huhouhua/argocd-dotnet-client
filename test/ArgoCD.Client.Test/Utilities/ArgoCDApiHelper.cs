// Copyright 2024 The argocd-dotnet-client Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
