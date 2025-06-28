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
using Newtonsoft.Json.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// A label selector requirement is a selector that contains values, a key, and an operator that
    /// relates the key and values.
    /// </summary>
    public class V1LabelSelectorRequirement
    {
        public V1LabelSelectorRequirement() { }


        /// <summary>
        /// key is the label key that the selector applies to. +patchMergeKey=key +patchStrategy=merge
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// operator represents a key's relationship to a set of values. Valid operators are In, NotIn, Exists and DoesNotExist.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// values is an array of string values. If the operator is In or NotIn, the values array must be non-empty.
        /// If the operator is Exists or DoesNotExist, the values array must be empty. This array is replaced during a strategic merge patch. +optional
        /// </summary>
        public string[] Values { get; set; }
    }
}
