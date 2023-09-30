using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Settings.Responses
{
    public sealed class ClusterSettings
    {
        public string AppLabelKey { get; set; }
        /// <summary>
        /// ConfigManagementPlugin contains config management plugin configuration
        /// </summary>
        public ConfigmanagementPlugin[] ConfigManagementPlugins { get; set; }
        public ClusterDexConfig DexConfig { get; set; }
        public bool ExecEnabled { get; set; }
        public ClusterGoogleAnalyticsConfig GoogleAnalytics { get; set; }
        public ClusterHelp Help { get; set; }
        public V1alpha1KustomizeOptions KustomizeOptions { get; set; }
        public string[] KustomizeVersions { get; set; }
        public ClusterOIDCConfig OidcConfig { get; set; }
        public string PasswordPattern { get; set; }
        public ClusterPlugin[] Plugins { get; set; }

        /// <summary>
        /// ResourceOverride holds configuration to customize resource diffing and health assessment
        /// </summary>
        public V1alpha1ResourceOverride ResourceOverrides { get; set; }
        public bool StatusBadgeEnabled { get; set; }
        public string StatusBadgeRootUrl { get; set; }
        public string TrackingMethod { get; set; }
        public string UiBannerContent { get; set; }
        public bool UiBannerPermanent { get; set; }
        public string UiBannerPosition { get; set; }
        public string UiBannerURL { get; set; }
        public string UiCssURL { get; set; }
        public string Url { get; set; }
        public bool UserLoginsDisabled { get; set; }
    }
}
