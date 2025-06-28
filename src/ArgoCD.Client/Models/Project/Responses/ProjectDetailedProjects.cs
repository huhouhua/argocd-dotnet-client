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
using ArgoCD.Client.Models.Cluster.Responses;
using ArgoCD.Client.Models.Repository.Responses;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class ProjectDetailedProjects
    {
        /// <summary>
        /// Cluster is the definition of a cluster resource
        /// </summary>
        public V1alpha1Cluster[] Clusters { get; set; }


        /// <summary>
        /// AppProject provides a logical grouping of applications, providing controls for:
        /// * where the apps may deploy to(cluster whitelist)
        /// * what may be deployed(repository whitelist, resource whitelist/blacklist)
        /// * who can access these applications(roles, OIDC group claims bindings)
        /// * and what they can do (RBAC policies)
        /// * automation access to these roles(JWT tokens)
        /// +genclient
        /// +genclient:noStatus
        /// +k8s:deepcopy-gen:interfaces=k8s.io/apimachinery/pkg/runtime.Object
        /// +kubebuilder:resource:path=appprojects,shortName=appproj;appprojs
        /// </summary
        public V1alpha1AppProject[] GlobalProjects { get; set; }

        /// <summary>
        /// AppProject provides a logical grouping of applications, providing controls for:
        /// * where the apps may deploy to(cluster whitelist)
        /// * what may be deployed(repository whitelist, resource whitelist/blacklist)
        /// * who can access these applications(roles, OIDC group claims bindings)
        /// * and what they can do (RBAC policies)
        /// * automation access to these roles(JWT tokens)
        /// +genclient
        /// +genclient:noStatus
        /// +k8s:deepcopy-gen:interfaces=k8s.io/apimachinery/pkg/runtime.Object
        /// +kubebuilder:resource:path=appprojects,shortName=appproj;appprojs
        /// </summary
        public V1alpha1AppProject Project { get; set; }

        /// <summary>
        /// Repository is a repository holding application configurations
        /// </summary>
        public V1alpha1Repository[] Repositories { get; set; }

    }
}
