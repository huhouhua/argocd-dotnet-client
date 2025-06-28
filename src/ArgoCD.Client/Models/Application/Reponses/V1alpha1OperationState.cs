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
    public class V1alpha1OperationState
    {

        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset FinishedAt { get; set; }

        /// <summary>
        /// Message holds any pertinent messages when attempting to perform operation (typically errors).
        /// </summary>
        public string Message { get; set; }


        public V1alpha1Operation Operation { get; set; }

        public string Phase { get; set; }

        public string RetryCount { get; set; }


        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset StartedAt { get; set; }


        public V1alpha1SyncOperationResult SyncResult { get; set; }
    }
}
