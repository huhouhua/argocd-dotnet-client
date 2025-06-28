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
