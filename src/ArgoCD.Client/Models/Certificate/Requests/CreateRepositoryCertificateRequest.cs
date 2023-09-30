using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.Certificate.Reponses;

namespace ArgoCD.Client.Models.Certificate.Requests
{
    public class CreateRepositoryCertificateRequest
    {
        /// <summary>
        /// RepositoryCertificateList is a collection of RepositoryCertificates
        /// </summary>
        public V1alpha1RepositoryCertificate[] Items { get; set; }


        /// <summary>
        /// ListMeta describes metadata that synthetic resources must have, including lists and
        /// various status objects.A resource may have only one of {ObjectMeta, ListMeta
        /// </summary>
        public V1ListMeta MetaData { get; set; }
    }
}
