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

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ApplicationStatus
    {

        public V1alpha1ApplicationCondition[] Conditions { get; set; }


        public string ControllerNamespace { get; set; }


        public V1alpha1HealthStatus Health { get; set; }


        public V1alpha1RevisionHistory[] History { get; set; }


        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset ObservedAt { get; set; }


        public V1alpha1OperationState OperationState { get; set; }

        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>

        public DateTimeOffset ReconciledAt { get; set; }


        public string ResourceHealthSource { get; set; }


        public V1alpha1ResourceStatus[] Resources { get; set; }


        public string SourceType { get; set; }


        public string[] SourceTypes { get; set; }


        public V1alpha1ApplicationSummary Summary { get; set; }


        public V1alpha1SyncStatus Sync { get; set; }
    }
}
