using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1alpha1ProjectRole
    {
        public V1alpha1ProjectRole() { }

        /// <summary>
        /// Description is a description of the role
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Groups are a list of OIDC group claims bound to this role
        /// </summary>
        public string[] Groups { get; set; }

        /// <summary>
        /// JWTTokens are a list of generated JWT tokens bound to this role
        /// </summary>
        public V1alpha1JWTToken[] JwtTokens { get; set; }

        /// <summary>
        /// Name is a name for this role
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Policies Stores a list of casbin formatted strings that define access policies for the role in the project
        /// </summary>
        public string[] Policies { get; set; }

    }
}
