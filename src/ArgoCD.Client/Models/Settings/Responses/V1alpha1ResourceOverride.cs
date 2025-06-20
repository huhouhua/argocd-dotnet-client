using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Settings.Responses
{
    public sealed class V1alpha1ResourceOverride
    {
        public string Actions { get; set; }
        public string HealthLua { get; set; }

        /// <summary>
        /// OverrideIgnoreDiff contains configurations about how fields should be ignored during diffs between the desired state and live state
        /// </summary>
        public string IgnoreDifferences { get; set; }

        /// <summary>
        /// KnownTypeField contains mapping between CRD field and known Kubernetes type. This is mainly used for unit conversion in unknown resources(e.g. 0.1 == 100mi)
        /// </summary>
        public V1alpha1KnownTypeField[] KnownTypeFields { get; set; }

        public string IgnoreResourceUpdates { get; set; }

        public bool UseOpenLibs { get; set; }
    }

}
