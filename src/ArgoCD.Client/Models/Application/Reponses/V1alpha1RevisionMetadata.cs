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

        /// <summary>
        /// Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.  +protobuf.options.marshal&#x3D;false +protobuf.as&#x3D;Timestamp +protobuf.options.(gogoproto.goproto_stringer)&#x3D;false
        /// </summary>

        public DateTimeOffset Date { get; set; }

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
