using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1alpha1SignatureKey
    {
        public V1alpha1SignatureKey() { }

        /// <summary>
        /// The ID of the key in hexadecimal notation
        /// </summary>
        public string KeyID { get; set; }
    }
}
