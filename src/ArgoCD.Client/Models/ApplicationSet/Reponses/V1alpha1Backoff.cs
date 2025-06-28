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
    public class V1alpha1Backoff
    {
        /// <summary>
        /// Duration is the amount to back off. Default unit is seconds, but could also be a duration (e.g. "2m", "1h")
        /// </summary>
        public string Duration { get; set; }


        /// <summary>
        /// Factor is a factor to multiply the base duration after each failed retry
        /// </summary>
        public string Factor { get; set; }

        /// <summary>
        /// MaxDuration is the maximum amount of time allowed for the backoff strategy
        /// </summary>
        public string MaxDuration { get; set; }
    }
}
