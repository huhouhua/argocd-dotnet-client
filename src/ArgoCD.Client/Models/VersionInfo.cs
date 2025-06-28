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
using Newtonsoft.Json;

namespace ArgoCD.Client.Models
{
    public sealed class VersionInfo
    {
        public string BuildDate { get; set; }
        public string Compiler { get; set; }
        public string GitCommit { get; set; }
        public string GitTag { get; set; }
        public string GitTreeState { get; set; }
        public string GoVersion { get; set; }
        public string HelmVersion { get; set; }
        public string JsonnetVersion { get; set; }
        public string KubectlVersion { get; set; }
        public string KustomizeVersion { get; set; }
        public string Platform { get; set; }
        public string Version { get; set; }
    }
}
