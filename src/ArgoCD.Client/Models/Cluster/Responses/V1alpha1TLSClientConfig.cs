using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Cluster.Responses
{
    public class V1alpha1TLSClientConfig
    {
        /// <summary>
        /// CAData holds PEM-encoded bytes (typically read from a root certificates bundle). CAData takes precedence over CAFile
        /// </summary>
        public string CaData { get; set; }

        /// <summary>
        /// CertData holds PEM-encoded bytes (typically read from a client certificate file). CertData takes precedence over CertFile
        /// </summary>
        public string CertData { get; set; }


        /// <summary>
        /// Insecure specifies that the server should be accessed without verifying the TLS certificate. For testing only.
        /// </summary>
        public bool Insecure { get; set; }


        /// <summary>
        /// KeyData holds PEM-encoded bytes (typically read from a client certificate key file). KeyData takes precedence over KeyFile
        /// </summary>
        public string KeyData { get; set; }


        /// <summary>
        /// ServerName is passed to the server for SNI and is used in the client to check server
        /// certificates against.If ServerName is empty, the hostname used to contact the server is used.
        /// </summary>
        public string ServerName { get; set; }

    }
}
