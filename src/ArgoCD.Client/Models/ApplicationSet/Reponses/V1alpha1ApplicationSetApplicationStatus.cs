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
    /// ApplicationSetApplicationStatus contains details about each Application managed by the ApplicationSet
    /// </summary>
    public class V1alpha1ApplicationSetApplicationStatus
    {
        /// <summary>
        /// Application contains the name of the Application resource
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset LastTransitionTime { get; set; }

        /// <summary>
        /// Message contains human-readable message indicating details about the status
        /// </summary>

        public string Message { get; set; }

        /// <summary>
        /// Status contains the AppSet's perceived status of the managed Application resource: (Waiting, Pending, Progressing, Healthy)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Step tracks which step this Application should be updated in
        /// </summary>
        public string Step { get; set; }

    }
}
