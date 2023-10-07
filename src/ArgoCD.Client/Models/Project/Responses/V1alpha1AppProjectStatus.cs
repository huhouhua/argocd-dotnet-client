using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1alpha1AppProjectStatus
    {

        /// <summary>
        /// JWTTokensByRole contains a list of JWT tokens issued for a given role
        /// </summary>
        public V1alpha1JWTTokens JwtTokensByRole { get; set; }
    }
}
