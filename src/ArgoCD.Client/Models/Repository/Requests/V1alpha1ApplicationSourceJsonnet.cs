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

namespace ArgoCD.Client.Models.Repository.Requests
{
    public class V1alpha1ApplicationSourceJsonnet
    {
        public V1alpha1ApplicationSourceJsonnet()
        {
        }

        /// <summary>
        /// ExtVars is a list of Jsonnet External Variables
        /// </summary>
        public V1alpha1JsonnetVar[] ExtVars { get; set; }

        /// <summary>
        /// TLAS is a list of Jsonnet Top-level Arguments
        /// </summary>
        public string[] Libs { get; set; }

        /// <summary>
        /// JsonnetVar represents a variable to be passed to jsonnet during manifest generation
        /// </summary>
        public V1alpha1JsonnetVar[] Tlas { get; set; }

    }
}
