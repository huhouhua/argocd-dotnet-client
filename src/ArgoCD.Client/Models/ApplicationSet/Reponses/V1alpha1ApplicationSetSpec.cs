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
using static System.Net.Mime.MediaTypeNames;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// V1alpha1ApplicationSetSpec represents a class of application set state.
    /// </summary>
    public class V1alpha1ApplicationSetSpec
    {
        /// <summary>
        /// ApplyNestedSelectors enables selectors defined within the generators of two level-nested matrix or merge generators
        /// </summary>
        public bool ApplyNestedSelectors { get; set; }

        /// <summary>
        /// 	ApplicationSetGenerator represents a generator at the top level of an ApplicationSet.
        /// </summary>
        public V1alpha1ApplicationSetGenerator[] Generators { get; set; }


        public bool GoTemplate { get; set; }

        public string[] GoTemplateOptions { get; set; }


        public V1alpha1ApplicationPreservedFields PreservedFields { get; set; }


        public V1alpha1ApplicationSetStrategy Strategy { get; set; }


        public V1alpha1ApplicationSetSyncPolicy SyncPolicy { get; set; }


        public V1alpha1ApplicationSetTemplate Template { get; set; }
    }

}
