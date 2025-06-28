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
    public class V1alpha1SCMProviderGenerator
    {
        public V1alpha1SCMProviderGeneratorAWSCodeCommit AwsCodeCommit { get; set; }

        public V1alpha1SCMProviderGeneratorAzureDevOps AzureDevOps { get; set; }


        public V1alpha1SCMProviderGeneratorBitbucket Bitbucket { get; set; }


        public V1alpha1SCMProviderGeneratorBitbucketServer BitbucketServer { get; set; }

        /// <summary>
        /// Which protocol to use for the SCM URL. Default is provider-specific but ssh if possible. Not all providers necessarily support all protocols.
        /// </summary>
        public string CloneProtocol { get; set; }

        /// <summary>
        /// Filters for which repos should be considered.
        /// </summary>
        public V1alpha1SCMProviderGeneratorFilter[] Filters { get; set; }


        public V1alpha1SCMProviderGeneratorGitea Gitea { get; set; }

        public V1alpha1SCMProviderGeneratorGithub Github { get; set; }


        public V1alpha1SCMProviderGeneratorGitlab Gitlab { get; set; }

        /// <summary>
        /// Standard parameters.
        /// </summary>
        public string RequeueAfterSeconds { get; set; }


        public V1alpha1ApplicationSetTemplate Template { get; set; }

        public Dictionary<string, string> Values { get; set; }
    }
}
