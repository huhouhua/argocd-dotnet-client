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

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ApplicationTree
    {
        public V1alpha1ApplicationTree() { }

        public V1alpha1HostInfo[] Hosts { get; set; }

        /// <summary>
        /// Nodes contains list of nodes which either directly managed by the application and children of directly managed nodes.
        /// </summary>

        public V1alpha1ResourceNode[] Nodes { get; set; }

        /// <summary>
        /// OrphanedNodes contains if or orphaned nodes: nodes which are not managed by the app but in the same namespace. List is populated only if orphaned resources enabled in app project.
        /// </summary>
        public V1alpha1ResourceNode[] OrphanedNodes { get; set; }


    }
}
