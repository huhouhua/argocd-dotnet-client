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

namespace ArgoCD.Client.Models.Cluster.Responses
{
    public class V1alpha1ClusterInfo
    {
        public V1alpha1ClusterInfo() { }

        /// <summary>
        /// APIVersions contains list of API versions supported by the cluster
        /// </summary>
        public string[] ApiVersions { get; set; }

        /// <summary>
        ///  ApplicationsCount is the number of applications managed by Argo CD on the cluster
        /// </summary>
        public string ApplicationsCount { get; set; }

        /// <summary>
        /// ClusterCacheInfo contains information about the cluster cache
        /// </summary>
        public V1alpha1ClusterCacheInfo CacheInfo { get;}


        /// <summary>
        /// ConnectionState contains information about remote resource connection state, currently used for clusters and repositories
        /// </summary>
        public V1alpha1ConnectionState ConnectionState { get; }

        /// <summary>
        ///  ServerVersion contains information about the Kubernetes version of the cluster
        /// </summary>
        public string ServerVersion { get; set; }
    }
}
