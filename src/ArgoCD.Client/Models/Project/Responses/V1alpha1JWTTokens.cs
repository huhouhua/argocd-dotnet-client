using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1alpha1JWTTokens
    {
        /// <summary>
        /// JWTTokens represents a list of JWT tokens
        /// </summary>
        public V1alpha1JWTToken[] Items { get; set; }
    }
}
