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
using static ArgoCD.Client.Models.ApplicationSet.Reponses.V1alpha1ApplicationSource;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public  class V1alpha1ApplicationSourceDirectory
    {
        public V1alpha1ApplicationSourceDirectory() { }


        /// <summary>
        /// Exclude contains a glob pattern to match paths against that should be explicitly excluded from being used during manifest generation
        /// </summary>
        public string Exclude { get; set; }

        /// <summary>
        /// Include contains a glob pattern to match paths against that should be explicitly included during manifest generation
        /// </summary>
        public string Include { get; set; }

        /// <summary>
        /// ApplicationSourceDirectory holds options for applications of type plain YAML or Jsonnet
        /// </summary>
        public V1alpha1ApplicationSourceJsonnet Jsonnet { get; set; }

        /// <summary>
        /// Recurse specifies whether to scan a directory recursively for manifests
        /// </summary>
        public bool Recurse { get; set; }

    }
}
