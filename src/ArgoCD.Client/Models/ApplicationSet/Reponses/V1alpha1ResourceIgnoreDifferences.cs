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
    public class V1alpha1ResourceIgnoreDifferences
    {
        public string Group { get; set; }

        public string[] JqPathExpressions { get; set; }

        public string[] JsonPointers { get; set; }

        public string Kind { get; set; }

        /// <summary>
        /// ManagedFieldsManagers is a list of trusted managers. Fields mutated by those managers will take precedence over the
        /// desired state defined in the SCM and won't be displayed in diffs
        /// </summary>
        public string[] ManagedFieldsManagers { get; set; }

        public string[] Name { get; set; }

        public string[] Namespace { get; set; }
    }
}
