using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1RevisionMetadata
    {

      
        public string Author { get; set; }


        public V1Time Date { get; set; }

        /// <summary>
        /// Message contains the message associated with the revision, most likely the commit message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// SignatureInfo contains a hint on the signer if the revision was signed with GPG, and signature verification is enabled.
        /// </summary>
        public string SignatureInfo { get; set; }


        public string[] Tags { get; set; }
    }
}
