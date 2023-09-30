using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Certificate.Requests
{
    public sealed class CreateCertificateOptions
    {
        public CreateCertificateOptions()
        {

        }

        /// <summary>
        /// Whether to upsert already existing certificates.
        /// </summary>
        public bool Upsert { get; set; }
    }
}
