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
    /// <summary>
    /// PullRequestGeneratorGitLab defines connection info specific to GitLab.
    /// </summary>
    public class V1alpha1PullRequestGeneratorGitLab
    {
        /// <summary>
        /// The GitLab API URL to talk to. If blank, uses https://gitlab.com/.
        /// </summary>
        public string Api { get; set; }

        public bool Insecure { get; set; }


        public string[] Labels { get; set; }

        /// <summary>
        /// GitLab project to scan. Required.
        /// </summary>
        public string Project { get; set; }

        public string PullRequestState { get; set; }


        public V1alpha1SecretRef TokenRef { get; set; }
    }
}
