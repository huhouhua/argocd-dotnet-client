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
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// ApplicationSetSyncPolicy configures how generated Applications will relate to their ApplicationSet.
    /// </summary>
    public class V1alpha1ApplicationSetSyncPolicy
    {
        /// <summary>
        /// ApplicationsSync represents the policy applied on the generated applications. Possible values are create-only, create-update, create-delete, sync +kubebuilder:validation:Optional +kubebuilder:validation:Enum=create-only;create-update;create-delete;sync
        /// </summary>
        public string ApplicationsSync { get; set; }

        /// <summary>
        /// PreserveResourcesOnDeletion will preserve resources on deletion. If PreserveResourcesOnDeletion is set to true, these Applications will not be deleted.
        /// </summary>
        public bool PreserveResourcesOnDeletion { get; set; }
    }
}
