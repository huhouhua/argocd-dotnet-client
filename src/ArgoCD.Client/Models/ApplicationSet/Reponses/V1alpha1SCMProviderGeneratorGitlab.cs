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

using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// SCMProviderGeneratorGitlab defines connection info specific to Gitlab.
    /// </summary>
    public class V1alpha1SCMProviderGeneratorGitlab
    {
        /// <summary>
        /// Scan all branches instead of just the default branch.
        /// </summary>
        public bool AllBranches { get; set; }

        /// <summary>
        /// The Gitlab API URL to talk to.
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// Gitlab group to scan. Required.  You can use either the project id (recommended) or the full namespaced path.
        /// </summary>
        public string Group { get; set; }


        public bool IncludeSubgroups { get; set; }


        public bool Insecure { get; set; }

        public V1alpha1SecretRef TokenRef { get; set; }
    }
}
