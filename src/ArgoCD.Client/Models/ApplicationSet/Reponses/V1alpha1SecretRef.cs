using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// Utility struct for a reference to a secret key.
    /// </summary>
    public class V1alpha1SecretRef
    {
        public string Key { get; set; }

        public string SecretName { get; set; }
    }
}
