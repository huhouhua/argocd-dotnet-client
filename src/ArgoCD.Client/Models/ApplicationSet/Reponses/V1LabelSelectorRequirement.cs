using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// A label selector requirement is a selector that contains values, a key, and an operator that
    /// relates the key and values.
    /// </summary>
    public class V1LabelSelectorRequirement
    {
        public V1LabelSelectorRequirement() { }


        /// <summary>
        /// key is the label key that the selector applies to. +patchMergeKey=key +patchStrategy=merge
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// operator represents a key's relationship to a set of values. Valid operators are In, NotIn, Exists and DoesNotExist.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// values is an array of string values. If the operator is In or NotIn, the values array must be non-empty.
        /// If the operator is Exists or DoesNotExist, the values array must be empty. This array is replaced during a strategic merge patch. +optional
        /// </summary>
        public string[] Values { get; set; }
    }
}
