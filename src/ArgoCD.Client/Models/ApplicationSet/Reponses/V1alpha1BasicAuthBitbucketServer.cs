using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// BasicAuthBitbucketServer defines the username/(password or personal access token) for Basic auth.
    /// </summary>
    public class V1alpha1BasicAuthBitbucketServer
    { 

        public V1alpha1SecretRef PasswordRef { get; set; }

        public string Username { get; set; }
    }
}
