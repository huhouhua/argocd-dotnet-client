using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Certificate.Reponses
{
    public class RepositoryCertificateList
    {
        public V1alpha1RepositoryCertificate[] Items { get; set; }
        public V1ListMeta Metadata { get; set; }

        

    }
}
