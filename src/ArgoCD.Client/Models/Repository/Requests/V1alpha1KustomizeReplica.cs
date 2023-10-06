using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public class V1alpha1KustomizeReplica
    {
        public V1alpha1KustomizeReplica()
        {
        }

        /// <summary>
        /// IntOrString is a type that can hold an int32 or a string.  When used in
        /// JSON or YAML marshalling and unmarshalling, it produces or consumes the
        /// inner type.This allows you to have, for example, a JSON field that can accept a name or number.
        /// TODO: Rename to Int32OrString
        /// </summary>
        public IntstrIntOrString Count { get; set; }

        /// <summary>
        /// Name of Deployment or StatefulSet
        /// </summary>
        public string Name { get; set; }

    }

    public class IntstrIntOrString
    {

        public int IntVal { get; set; }
        public string StrVal { get; set; }
        public string Type { get; set; }
    }
}
