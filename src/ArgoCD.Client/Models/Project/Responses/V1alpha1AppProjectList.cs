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
using System.Diagnostics.Metrics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1alpha1AppProjectList
    {
        public V1alpha1AppProjectList() { }

        /// <summary>
        /// AppProject provides a logical grouping of applications, providing controls for:
        /// * where the apps may deploy to(cluster whitelist)
        /// * what may be deployed(repository whitelist, resource whitelist/blacklist)
        /// * who can access these applications(roles, OIDC group claims bindings)
        /// * and what they can do (RBAC policies)
        /// * automation access to these roles(JWT tokens)
        /// </summary>
        public V1alpha1AppProject[] Items { get; set; }

        /// <summary>
        ///ListMeta describes metadata that synthetic resources must have, including lists and
        ///various status objects.A resource may have only one of {ObjectMeta, ListMeta}
        /// </summary>
        public V1ListMeta MetaData { get; set; }
    }
}
