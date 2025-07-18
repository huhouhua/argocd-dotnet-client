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
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// PullRequestGeneratorBitbucket defines connection info specific to Bitbucket.
    /// </summary>
    public class V1alpha1PullRequestGeneratorBitbucket
    {
        /// <summary>
        /// The Bitbucket REST API URL to talk to. If blank, uses https://api.bitbucket.org/2.0.
        /// </summary>
        public string Api { get; set; }


        public V1alpha1BasicAuthBitbucketServer BasicAuth { get; set; }


        public V1alpha1BearerTokenBitbucketCloud BearerToken { get; set; }

        /// <summary>
        /// Workspace to scan. Required.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Repo name to scan. Required.
        /// </summary>
        public string Repo { get; set; }
    }
}
