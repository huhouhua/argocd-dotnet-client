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
        /// ExecProviderConfig is config used to call an external command to perform cluster authentication
        /// See: https://godoc.org/k8s.io/client-go/tools/clientcmd/api#ExecConfig
        /// </summary>
        public V1alpha1ExecProviderConfig ExecProviderConfig { get; set; }

        public string Password { get; set; }

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
