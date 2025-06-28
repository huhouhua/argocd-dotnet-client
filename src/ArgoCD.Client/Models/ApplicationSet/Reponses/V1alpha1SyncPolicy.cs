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
    public class V1alpha1SyncPolicy
    {
        public V1alpha1SyncPolicy() { }


        /// <summary>
        /// SyncPolicyAutomated controls the behavior of an automated sync
        /// </summary>
        public V1alpha1SyncPolicyAutomated Automated { get; set; }

        public V1alpha1ManagedNamespaceMetadata ManagedNamespaceMetadata { get; set; }

        /// <summary>
        /// RetryStrategy contains information about the strategy to apply when a sync failed
        /// </summary>
        public V1alpha1RetryStrategy Retry { get; set; }

        /// <summary>
        /// Options allow you to specify whole app sync-options
        /// </summary>
        public string[] SyncOptions { get; set; }
    }
}
