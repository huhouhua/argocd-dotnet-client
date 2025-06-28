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

namespace ArgoCD.Client.Models.Repository.Responses
{
    public class RepositoryHelmAppSpec
    {
        /// <summary>
        ///  helm file parameters
        /// </summary>
        public V1alpha1HelmFileParameter[]  FileParameters { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// the output of `helm inspect values`
        /// </summary>
        public V1alpha1HelmParameter[] Parameters { get; set; }


        public string[] ValueFiles { get; set; }

        /// <summary>
        /// the contents of values.yaml
        /// </summary>
        public string Values { get; set; }
    }
}
