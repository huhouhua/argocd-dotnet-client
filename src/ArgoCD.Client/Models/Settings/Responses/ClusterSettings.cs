// Copyright 2024 The argocd-dotnet-client Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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

        public string ControllerNamespace { get; set; }

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
        public Dictionary<string,V1alpha1ResourceOverride> ResourceOverrides { get; set; }
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
