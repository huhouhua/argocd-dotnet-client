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

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1alpha1SyncWindow
    {
        public V1alpha1SyncWindow() { }

        /// <summary>
        /// Applications contains a list of applications that the window will apply to
        /// </summary>
        public string[] Applications { get; set; }

        /// <summary>
        /// Clusters contains a list of clusters that the window will apply to
        /// </summary>
        public string[] Clusters { get; set; }

        /// <summary>
        /// Duration is the amount of time the sync window will be open
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// Kind defines if the window allows or blocks syncs
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// ManualSync enables manual syncs when they would otherwise be blocked
        /// </summary>
        public bool ManualSync { get; set; }

        /// <summary>
        /// Namespaces contains a list of namespaces that the window will apply to
        /// </summary>
        public string[] Namespaces { get; set; }

        /// <summary>
        /// Schedule is the time the window will begin, specified in cron format
        /// </summary>
        public string Schedule { get; set; }

        /// <summary>
        /// TimeZone of the sync that will be applied to the schedule
        /// </summary>
        public string TimeZone { get; set; }
    }
}
