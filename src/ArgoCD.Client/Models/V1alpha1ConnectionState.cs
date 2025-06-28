using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models
{
    public class V1alpha1ConnectionState
    {
        public V1alpha1ConnectionState() { }

        /// <summary>
        /// Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.  +protobuf.options.marshal&#x3D;false +protobuf.as&#x3D;Timestamp +protobuf.options.(gogoproto.goproto_stringer)&#x3D;false
        /// </summary>
        public DateTimeOffset AttemptedAt { get; set; }

        /// <summary>
        /// Message contains human readable information about the connection status
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///  Status contains the current status indicator for the connection
        /// </summary>
        public string Status { get; set; }
    }
}
