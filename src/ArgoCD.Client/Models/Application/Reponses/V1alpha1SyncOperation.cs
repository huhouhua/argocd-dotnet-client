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

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;
using ArgoCD.Client.Models.ApplicationSet.Reponses;

namespace ArgoCD.Client.Models.Application.Reponses
{
    /// <summary>
    /// SyncOperation contains details about a sync operation.
    /// </summary>
    public class V1alpha1SyncOperation
    {

        public bool DryRun { get; set; }


        public string[] Manifests { get; set; }


        public bool Prune { get; set; }


        public V1alpha1SyncOperationResource[] Resources { get; set; }

        /// <summary>
        /// Revision is the revision (Git) or chart version (Helm) which to sync the application to If omitted, will use the revision specified in app spec.
        /// </summary>
        public string Revision { get; set; }

        /// <summary>
        /// Revisions is the list of revision (Git) or chart version (Helm) which to sync each source in sources field for the application to If omitted, will use the revision specified in app spec.
        /// </summary>
        public string[] Revisions { get; set; }


        public V1alpha1ApplicationSource Source { get; set; }


        public V1alpha1ApplicationSource[] Sources { get; set; }


        public string[] SyncOptions { get; set; }


        public V1alpha1SyncStrategy SyncStrategy { get; set; }
    }
}
