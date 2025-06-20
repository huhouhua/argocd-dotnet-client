using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Settings.Responses
{
    public sealed class ClusterGoogleAnalyticsConfig
    {
        public bool AnonymizeUsers { get; set; }

        public string TrackingID { get; set; }
    }
}
