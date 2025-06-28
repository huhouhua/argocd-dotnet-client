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

namespace ArgoCD.Client.Models.Cluster.Responses
{
    public class V1alpha1ExecProviderConfig
    {
        /// <summary>
        /// Preferred input version of the ExecInfo
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Arguments to pass to the command when executing it
        /// </summary>
        public string[] Args { get; set; }
        /// <summary>
        /// Command to execute
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// Env defines additional environment variables to expose to the process
        /// </summary>
        public string[] Env { get; set; }

        /// <summary>
        ///  This text is shown to the user when the executable doesn't seem to be present
        /// </summary>
        public string InstallHint { get; set; }
    }
}
