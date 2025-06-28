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
using System.Text;

namespace ArgoCD.Client.Models.Cluster.Responses
{
    public class V1alpha1ClusterConfig
    {
        /// <summary>
        /// AWSAuthConfig is an AWS IAM authentication configuration
        /// </summary>
        public V1alpha1AWSAuthConfig AwsAuthConfig { get; set; }

        /// <summary>
        /// Server requires Bearer authentication. This client will not attempt to use refresh tokens for an OAuth2 flow.
        /// TODO: demonstrate an OAuth2 compatible client.
        /// </summary>
        public string BearerToken { get; set; }

        /// <summary>
        /// DisableCompression bypasses automatic GZip compression requests to the server.
        /// </summary>
        public bool DisableCompression { get; set; }

        /// <summary>
        /// ExecProviderConfig is config used to call an external command to perform cluster authentication
        /// See: https://godoc.org/k8s.io/client-go/tools/clientcmd/api#ExecConfig
        /// </summary>
        public V1alpha1ExecProviderConfig ExecProviderConfig { get; set; }

        public string Password { get; set; }

        public string ProxyUrl { get; set; }

        /// <summary>
        /// TLSClientConfig contains settings to enable transport layer security
        /// </summary>
        public V1alpha1TLSClientConfig TlsClientConfig { get; set; }

        /// <summary>
        /// Server requires Basic authentication
        /// </summary>
        public string Username { get; set; }
    }
}
