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
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1LabelSelector
    {
        public V1LabelSelector() { }

        /// <summary>
        /// matchExpressions is a list of label selector requirements. The requirements are ANDed. +optional
        /// </summary>
        public V1LabelSelectorRequirement[] MatchExpressions { get; set; }

        /// <summary>
        /// matchLabels is a map of {key,value} pairs. A single {key,value} in the matchLabels
        /// map is equivalent to an element of matchExpressions, whose key field is "key", the
        /// operator is "In", and the values array contains only "value". The requirements are ANDed. +optional
        /// </summary>
        public Dictionary<string, string> MatchLabels { get; set; }
    }
}
