using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1LabelSelector
    {
        public V1LabelSelector() { }

        /// <summary>
        /// matchExpressions is a list of label selector requirements. The requirements are ANDed. +optional
        /// </summary>
        public V1LabelSelectorRequirement[] MatchExpressions { get; set; }

        /// <summary>
        /// matchLabels is a map of {key,value} pairs. A single {key,value} in the matchLabels
        /// map is equivalent to an element of matchExpressions, whose key field is "key", the
        /// operator is "In", and the values array contains only "value". The requirements are ANDed. +optional
        /// </summary>
        public string[] MatchLabels { get; set; }
    }
}
