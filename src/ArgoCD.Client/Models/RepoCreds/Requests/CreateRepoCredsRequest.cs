using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.RepoCreds.Requests
{
    public class CreateRepoCredsRequest
    {
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
        public string GcpServiceAccountKey { get; set; }

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
        ///  Password for authenticating at the repo server
        /// </summary>
        public string Password { get; set; }

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
        /// URL is the URL that this credentials matches to
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Username for authenticating at the repo server
        /// </summary>
        public string Username { get; set; }

    }
}
