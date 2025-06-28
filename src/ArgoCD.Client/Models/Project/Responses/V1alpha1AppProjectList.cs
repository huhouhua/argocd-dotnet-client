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
