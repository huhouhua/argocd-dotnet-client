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

namespace ArgoCD.Client.Models.Repository.Requests
{
    public class CreateRepositoryRequest
    {
        /// <summary>
        /// ConnectionState contains information about remote resource connection state, currently used for clusters and repositories
        /// </summary>
        public V1alpha1ConnectionState ConnectionState { get; set; }

        /// <summary>
        /// EnableLFS specifies whether git-lfs support should be enabled for this repo. Only valid for Git repositories.
        /// </summary>
        public bool EnableLfs { get; set; }

        /// <summary>
        /// EnableOCI specifies whether helm-oci support should be enabled for this repo
        /// </summary>
        public bool EnableOCI { get; set; }

        /// <summary>
        /// ForceHttpBasicAuth specifies whether Argo CD should attempt to force basic auth for HTTP connections
        /// </summary>
        public bool ForceHttpBasicAuth { get; set; }

        /// <summary>
        /// GCPServiceAccountKey specifies the service account key in JSON format to be used for getting credentials to Google Cloud Source repos
        /// </summary>
        public bool GcpServiceAccountKey { get; set; }

        /// <summary>
        /// GithubAppEnterpriseBaseURL specifies the GitHub API URL for GitHub app authentication. If empty will default to https://api.github.com
        /// </summary>
        public string GithubAppEnterpriseBaseUrl { get; set; }

        /// <summary>
        /// GithubAppId specifies the Github App ID of the app used to access the repo for GitHub app authentication
        /// </summary>
        public string GithubAppID { get; set; }

        /// <summary>
        /// GithubAppInstallationId specifies the ID of the installed GitHub App for GitHub app authentication
        /// </summary>
        public string GithubAppInstallationID { get; set; }

        /// <summary>
        /// GithubAppPrivateKey specifies the private key PEM data for authentication via GitHub app
        /// </summary>
        public string GithubAppPrivateKey { get; set; }

        /// <summary>
        /// Whether credentials were inherited from a credential set
        /// </summary>
        public bool InheritedCreds { get; set; }

        /// <summary>
        /// Insecure specifies whether the connection to the repository ignores any errors when verifying TLS certificates or SSH host keys
        /// </summary>
        public bool Insecure { get; set; }


        /// <summary>
        /// InsecureIgnoreHostKey should not be used anymore, Insecure is favoured Used only for Git repos
        /// </summary>
        public bool InsecureIgnoreHostKey { get; set; }

        /// <summary>
        ///  Name specifies a name to be used for this repo. Only used with Helm repos
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Password for authenticating at the repo server
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///  Reference between project and repository that allow you automatically to be added as item inside SourceRepos project entity
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Repo contains the URL to the remote repository
        /// </summary>
        public string Repo { get; set; }

        /// <summary>
        /// Proxy specifies the HTTP/HTTPS proxy used to access repos at the repo server
        /// </summary>
        public string Proxy { get; set; }

        /// <summary>
        /// SSHPrivateKey contains the private key data for authenticating at the repo server using SSH (only Git repos)
        /// </summary>
        public string SshPrivateKey { get; set; }

        /// <summary>
        // /TLSClientCertData specifies the TLS client cert data for authenticating at the repo server
        /// </summary>
        public string TlsClientCertData { get; set; }

        /// <summary>
        ///  TLSClientCertKey specifies the TLS client cert key for authenticating at the repo server
        /// </summary>
        public string TlsClientCertKey { get; set; }

        /// <summary>
        /// Type specifies the type of the repoCreds. Can be either "git" or "helm. "git" is assumed if empty or absent.
        /// </summary>
        public string Type { get; set; }


        /// <summary>
        /// Username for authenticating at the repo server
        /// </summary>
        public string Username { get; set; }
    }
}
