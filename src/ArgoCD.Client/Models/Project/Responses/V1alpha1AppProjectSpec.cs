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

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1alpha1AppProjectSpec
    {
        /// <summary>
        /// ClusterResourceBlacklist contains list of blacklisted cluster level resources
        /// </summary>
        public V1GroupKind[] ClusterResourceBlacklist { get; set; }

        /// <summary>
        /// ClusterResourceWhitelist contains list of whitelisted cluster level resources
        /// </summary>
        public V1GroupKind[] ClusterResourceWhitelist { get; set; }

        /// <summary>
        /// Description contains optional project description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Destinations contains list of destinations available for deployment
        /// </summary>
        public V1alpha1ApplicationDestination[] Destinations { get; set; }

        /// <summary>
        /// NamespaceResourceBlacklist contains list of blacklisted namespace level resources
        /// </summary>
        public V1GroupKind[] NamespaceResourceBlacklist { get; set; }


        /// <summary>
        /// NamespaceResourceWhitelist contains list of whitelisted namespace level resources
        /// </summary>
        public V1GroupKind[] NamespaceResourceWhitelist { get; set; }

        /// <summary>
        /// OrphanedResourcesMonitorSettings holds settings of orphaned resources monitoring
        /// </summary>
        public V1alpha1OrphanedResourcesMonitorSettings OrphanedResources { get; set; }

        /// <summary>
        /// Roles are user defined RBAC roles associated with this project
        /// </summary>
        public V1alpha1ProjectRole[] Roles { get; set; }

        /// <summary>
        /// SignatureKeys contains a list of PGP key IDs that commits in Git must be signed with in order to be allowed for sync
        /// </summary>
        public V1alpha1SignatureKey[] SignatureKeys { get; set; }

        /// <summary>
        /// SourceRepos contains list of repository URLs which can be used for deployment
        /// </summary>
        public string[] SourceRepos { get; set; }

        /// <summary>
        /// SyncWindow contains the kind, time, duration and attributes that are used to assign the syncWindows to apps
        /// </summary>
        public V1alpha1SyncWindow[] SyncWindows { get; set; }
    }
}
