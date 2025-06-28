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
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1PluginGenerator
    {
        public V1alpha1PluginGenerator() { }

        public V1alpha1PluginConfigMapRef ConfigMapRef { get; set; }

        public V1alpha1PluginInput Input { get; set; }

        /// <summary>
        /// RequeueAfterSeconds determines how long the ApplicationSet controller will wait before reconciling the ApplicationSet again.
        /// </summary>
        public string RequeueAfterSeconds { get; set; }

        public V1alpha1ApplicationSetTemplate Template { get; set; }


        /// <summary>
        /// Values contains key/value pairs which are passed directly as parameters to the template. These values will not be sent as parameters to the plugin.
        /// </summary>
        public Dictionary<string, string> Values { get; set; }
    }
}
