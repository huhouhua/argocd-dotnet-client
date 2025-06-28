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
    public class V1alpha1RetryStrategy
    {
        public V1alpha1RetryStrategy() { }

        /// <summary>
        /// Backoff is the backoff strategy to use on subsequent retries for failing syncs
        /// </summary>
        public V1alpha1Backoff Backoff { get; set; }

        /// <summary>
        /// Limit is the maximum number of attempts for retrying a failed sync. If set to 0, no retries will be performed.
        /// </summary>
        public string Limit { get; set; }
    }
}
