using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;

namespace ArgoCD.Client.Models.Cluster.Responses
{
    public class V1alpha1AWSAuthConfig
    {
        /// <summary>
        ///  ClusterName contains AWS cluster name
        /// </summary>
        public string ClusterName { get; set; }

        /// <summary>
        /// Profile contains optional role ARN. If set then AWS IAM Authenticator uses the profile to perform cluster operations instead of the default AWS credential provider chain.
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// RoleARN contains optional role ARN.If set then AWS IAM Authenticator assume a role to perform cluster operations instead of the default AWS credential provider chain.
        /// </summary>
        public string RoleARN { get; set; }
    }
}
