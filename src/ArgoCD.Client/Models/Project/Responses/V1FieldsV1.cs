using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1FieldsV1
    {
        public V1FieldsV1() { }

        /// <summary>
        /// Raw is the underlying serialization of this object.
        /// </summary>
        public string Raw { get; set; }
    }
}
