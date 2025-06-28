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
    public class V1alpha1HelmParameter
    {
        /// <summary>
        /// ForceString determines whether to tell Helm to interpret booleans and numbers as strings
        /// </summary>
        public bool ForceString { get; set; }

        /// <summary>
        /// Name is the name of the Helm parameter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value is the value for the Helm parameter
        /// </summary>
        public string Value { get; set; }
    }
}
