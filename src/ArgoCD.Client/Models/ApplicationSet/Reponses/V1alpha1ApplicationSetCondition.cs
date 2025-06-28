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
    /// ApplicationSetCondition contains details about an applicationset condition, which is usally an error or warning
    /// </summary>
    public class V1alpha1ApplicationSetCondition
    {
        /// <summary>
        ///Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.
        /// </summary>
        public DateTimeOffset LastTransitionTime { get; set; }

        /// <summary>
        /// Message contains human-readable message indicating details about condition
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        ///Single word camelcase representing the reason for the status eg ErrorOccurred
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// True/False/Unknown
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Type is an applicationset condition type
        /// </summary>
        public string Type { get; set; }
    }
}
