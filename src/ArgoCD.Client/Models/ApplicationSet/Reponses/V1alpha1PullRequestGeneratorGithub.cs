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
    /// PullRequestGenerator defines connection info specific to GitHub.
    /// </summary>
    public class V1alpha1PullRequestGeneratorGithub
    {
        /// <summary>
        /// The GitHub API URL to talk to. If blank, use https://api.github.com/.
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// AppSecretName is a reference to a GitHub App repo-creds secret with permission to access pull requests.
        /// </summary>

        public string AppSecretName { get; set; }


        public string[] Labels { get; set; }

        /// <summary>
        /// GitHub org or user to scan. Required.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// GitHub repo name to scan. Required.
        /// </summary>
        public string Repo { get; set; }


        public V1alpha1SecretRef TokenRef { get; set; }
    }
}
