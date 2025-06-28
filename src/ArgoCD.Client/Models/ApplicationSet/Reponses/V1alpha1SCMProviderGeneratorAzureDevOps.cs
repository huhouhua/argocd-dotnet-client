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
    /// SCMProviderGeneratorAzureDevOps defines connection info specific to Azure DevOps.
    /// </summary>
    public class V1alpha1SCMProviderGeneratorAzureDevOps
    {

        public V1alpha1SecretRef AccessTokenRef { get; set; }

        /// <summary>
        /// Scan all branches instead of just the default branch.
        /// </summary>
        public bool AllBranches { get; set; }

        /// <summary>
        /// The URL to Azure DevOps. If blank, use https://dev.azure.com.
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// Azure Devops organization. Required. E.g. \&quot;my-organization\&quot;.
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// Azure Devops team project. Required. E.g. \&quot;my-team\&quot;.
        /// </summary>
        public string TeamProject { get; set; }
    }
}
