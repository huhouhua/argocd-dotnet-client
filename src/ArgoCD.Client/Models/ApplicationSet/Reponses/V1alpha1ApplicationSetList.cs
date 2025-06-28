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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// ApplicationSetList contains a list of ApplicationSet +k8s:deepcopy-gen:interfaces=k8s.io/apimachinery/pkg/runtime.Object +kubebuilder:object:root=true
    /// </summary>
    public  class V1alpha1ApplicationSetList
    {
        public List<V1alpha1ApplicationSet> Items { get; set; }

        public V1ListMeta Metadata { get; set; }
    }
}
