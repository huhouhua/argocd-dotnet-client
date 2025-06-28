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

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1SCMProviderGeneratorFilter
    {
        /// <summary>
        /// A regex which must match the branch name.
        /// </summary>
        public string BranchMatch { get; set; }

        /// <summary>
        /// A regex which must match at least one label.
        /// </summary>
        public string LabelMatch { get; set; }

        /// <summary>
        /// An array of paths, all of which must not exist.
        /// </summary>
        public List<string> PathsDoNotExist { get; set; }

        /// <summary>
        /// An array of paths, all of which must exist.
        /// </summary>
        public List<string> PathsExist { get; set; }

        /// <summary>
        /// A regex for repo names.
        /// </summary>
        public string RepositoryMatch { get; set; }
    }
}
