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

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// SyncPolicyAutomated controls the behavior of an automated sync
    /// </summary>
    public class V1alpha1SyncPolicyAutomated
    {
        /// <summary>
        /// AllowEmpty allows apps have zero live resources (default: false)
        /// </summary>
        public bool AllowEmpty { get; set; }

        /// <summary>
        /// Prune specifies whether to delete resources from the cluster that are not found in the sources anymore as part of automated sync (default: false)
        /// </summary>
        public bool Prune { get; set; }


        /// <summary>
        /// SelfHeal specifies whether to revert resources back to their desired state upon modification in the cluster (default: false)
        /// </summary>
        public bool SelfHeal { get; set; }
    }
}
