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

namespace ArgoCD.Client.Models.Cluster.Requests
{
    public sealed class ClusterQueryOptions
    {
        public ClusterQueryOptions() { }

        public string Server { get; set; }

        public string Name { get; set; }


        /// <summary>
        /// type is the type of the specified cluster identifier ( "server" - default, "name" ).
        /// </summary>
        public string IdType { get; set; }

        /// <summary>
        /// value holds the cluster server URL or cluster name.
        /// </summary>
        public string IdValue { get; set; }
    }
}
