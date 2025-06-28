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
    /// 	PullRequestGeneratorAzureDevOps defines connection info specific to AzureDevOps.
    /// </summary>
    public class V1alpha1PullRequestGeneratorAzureDevOps
    {
        /// <summary>
        /// The Azure DevOps API URL to talk to. If blank, use https://dev.azure.com/.
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// Labels is used to filter the PRs that you want to target
        /// </summary>
        public string[] Labels { get; set; }

        /// <summary>
        /// Azure DevOps org to scan. Required.
        /// </summary>
        public string Organization { get; set; }


        /// <summary>
        /// Azure DevOps project name to scan. Required.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Azure DevOps repo name to scan. Required
        /// </summary>
        public string Repo { get; set; }

        public V1alpha1SecretRef TokenRef { get; set; }
    }
}
