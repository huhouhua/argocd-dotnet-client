using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.Project.Responses;

namespace ArgoCD.Client.Models.Project.Requests
{
    /// <summary>
    /// CreateProjectRequest defines project creation parameters.
    /// </summary>
    public class CreateProjectRequest
    {
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
        /// </summary>
        public V1alpha1AppProject Project { get; set; }


        public bool Upsert { get; set; }
    }
}
