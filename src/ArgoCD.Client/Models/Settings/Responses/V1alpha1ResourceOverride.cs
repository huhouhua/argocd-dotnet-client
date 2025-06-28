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

namespace ArgoCD.Client.Models.Settings.Responses
{
    public sealed class V1alpha1ResourceOverride
    {
        public string Actions { get; set; }
        public string HealthLua { get; set; }

        /// <summary>
        /// OverrideIgnoreDiff contains configurations about how fields should be ignored during diffs between the desired state and live state
        /// </summary>
        public string IgnoreDifferences { get; set; }

        /// <summary>
        /// KnownTypeField contains mapping between CRD field and known Kubernetes type. This is mainly used for unit conversion in unknown resources(e.g. 0.1 == 100mi)
        /// </summary>
        public V1alpha1KnownTypeField[] KnownTypeFields { get; set; }

        public string IgnoreResourceUpdates { get; set; }

        public bool UseOpenLibs { get; set; }
    }

}
