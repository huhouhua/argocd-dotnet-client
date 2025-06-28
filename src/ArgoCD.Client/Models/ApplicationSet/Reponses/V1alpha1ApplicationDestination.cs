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

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationDestination
    {
        public V1alpha1ApplicationDestination() { }

        /// <summary>
        /// Name is an alternate way of specifying the target cluster by its symbolic name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Namespace specifies the target namespace for the application's resources. The namespace will only be set for namespace-scoped resources that have not set a value for .metadata.namespace
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Server specifies the URL of the target cluster and must be set to the Kubernetes control plane API
        /// </summary>
        public string Server { get; set; }
    }
}
