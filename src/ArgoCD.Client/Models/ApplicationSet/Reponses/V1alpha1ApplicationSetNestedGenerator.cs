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
    /// 	ApplicationSetNestedGenerator represents a generator nested within a combination-type generator(MatrixGenerator or MergeGenerator).
    /// </summary>
    public class V1alpha1ApplicationSetNestedGenerator
    {
        public V1alpha1DuckTypeGenerator ClusterDecisionResource { get; set; }

        public V1alpha1ClusterGenerator Clusters { get; set; }

        public V1alpha1GitGenerator Git { get; set; }

        public V1alpha1ListGenerator List { get; set; }

        public V1JSON Matrix { get; set; }

        public V1JSON Merge { get; set; }

        public V1alpha1PluginGenerator Plugin { get; set; }

        public V1alpha1PullRequestGenerator PullRequest { get; set; }

        public V1alpha1SCMProviderGenerator ScmProvider { get; set; }

        public V1LabelSelector Selector { get; set; }

    }
}
