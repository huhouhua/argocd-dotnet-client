using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Certificate.Requests
{
    public sealed class DeleteCertificateOptions
    {
        /// <summary>
        /// A file-glob pattern (not regular expression) the host name has to match.
        /// </summary>
        public string HostNamePattern { get; set; }

        /// <summary>
        /// The type of the certificate to match (ssh or https).
        /// </summary>
        public string CertType { get; set; }

        /// <summary>
        /// The sub type of the certificate to match (protocol dependent, usually only used for ssh certs).
        /// </summary>
        public string CertSubType { get; set; }
    }
}
