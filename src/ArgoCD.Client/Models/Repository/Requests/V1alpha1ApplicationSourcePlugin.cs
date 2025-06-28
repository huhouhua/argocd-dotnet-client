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
    public class V1alpha1ApplicationSourcePlugin
    {
        /// <summary>
        /// EnvEntry represents an entry in the application's environment
        /// </summary>
        public Applicationv1alpha1EnvEntry[] Env { get; set; }


        public string Name { get; set; }


        public V1alpha1ApplicationSourcePluginParameter[] Parameters { get; set; }


    }

    public class Applicationv1alpha1EnvEntry
    {
        /// <summary>
        /// Name is the name of the variable, usually expressed in uppercase
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value is the value of the variable
        /// </summary>
        public string Value { get; set; }

    }

    public class V1alpha1ApplicationSourcePluginParameter
    {
        /// <summary>
        /// Array is the value of an array type parameter.
        /// </summary>
        public string[] Array { get; set; }

        /// <summary>
        /// Map is the value of a map type parameter.
        /// </summary>
        public string[] Map { get; set; }
        /// <summary>
        /// Name is the name identifying a parameter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// String_ is the value of a string type parameter
        /// </summary>
        public string String { get; set; }

    }
}
