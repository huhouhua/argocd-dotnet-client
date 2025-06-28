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
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// ClusterGenerator defines a generator to match against clusters registered with ArgoCD.
    /// </summary>
    public class V1alpha1ClusterGenerator
    {
        public V1alpha1ClusterGenerator() { }

        /// <summary>
        /// A label selector is a label query over a set of resources. The result of matchLabels and
        /// matchExpressions are ANDed.An empty label selector matches all objects.A null
        /// label selector matches no objects. +structType=atomic
        /// </summary>
        public V1LabelSelector Selector { get; set; }

        /// <summary>
        /// ApplicationSetTemplate represents argocd ApplicationSpec
        /// </summary>
        public V1alpha1ApplicationSetTemplate Template { get; set; }

        /// <summary>
        /// Values contains key/value pairs which are passed directly as parameters to the template
        /// </summary>
        public Dictionary<string, string> Values { get; set; }
    }
}
