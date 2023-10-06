using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public  class RuntimeRawExtension
    {
        /// <summary>
        /// Raw is the underlying serialization of this object.
        /// TODO: Determine how to detect ContentType and ContentEncoding of 'Raw' data.
        /// </summary>
        public string Raw { get; set; }
    }
}
