using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ResourceIgnoreDifferences
    {
        public string Group { get; set; }

        public string[] JqPathExpressions { get; set; }

        public string[] JsonPointers { get; set; }

        public string Kind { get; set; }

        /// <summary>
        /// ManagedFieldsManagers is a list of trusted managers. Fields mutated by those managers will take precedence over the
        /// desired state defined in the SCM and won't be displayed in diffs
        /// </summary>
        public string[] ManagedFieldsManagers { get; set; }

        public string[] Name { get; set; }

        public string[] Namespace { get; set; }
    }
}
