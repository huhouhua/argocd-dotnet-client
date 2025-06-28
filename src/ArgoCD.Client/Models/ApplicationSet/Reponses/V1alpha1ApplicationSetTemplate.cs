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
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSetTemplate
    {
        /// <summary>
        /// ApplicationSetTemplateMeta represents the Argo CD application fields that may
        /// be used for Applications generated from the ApplicationSet(based on metav1.ObjectMeta)
        /// </summary>
        public V1alpha1ApplicationSetTemplateMeta Metadata { get; set; }

        /// <summary>
        /// ApplicationSpec represents desired application state. Contains link to repository with application definition and additional parameters link definition revision.
        /// </summary>
        public V1alpha1ApplicationSpec Spec { get; set; }
    }
}
