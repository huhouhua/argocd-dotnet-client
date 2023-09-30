using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Settings.Responses
{
    public sealed class V1alpha1OverrideIgnoreDiff
    {
        /// <summary>
        /// JSONPointers is a JSON path list following the format defined in RFC4627 (https://datatracker.ietf.org/doc/html/rfc6902#section-3)
        /// </summary>
        public string[] JSONPointers { get; set; }

        /// <summary>
        /// JQPathExpressions is a JQ path list that will be evaludated during the diff process
        /// </summary>
        public string[] JqPathExpressions { get; set; }

        /// <summary>
        /// ManagedFieldsManagers is a list of trusted managers. Fields mutated by those managers will take precedence over the desired state defined in the SCM and won't be displayed in diffs
        /// </summary>
        public string[] ManagedFieldsManagers { get; set; }
    }
}
