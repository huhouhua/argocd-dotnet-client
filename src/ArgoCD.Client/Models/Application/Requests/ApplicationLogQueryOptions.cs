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
using Newtonsoft.Json.Linq;

namespace ArgoCD.Client.Models.Application.Requests
{
    public sealed class ApplicationLogQueryOptions
    {
        public ApplicationLogQueryOptions() { }

        public string Namespace { get; set; }

        public string PodName { get; set; }

        public string Container { get; set; }

        public string SinceSeconds { get; set; }

        /// <summary>
        /// Represents seconds of UTC time since Unix epoch
        /// 1970-01-01T00:00:00Z.Must be from 0001-01-01T00:00:00Z to
        /// 9999-12-31T23:59:59Z inclusive
        /// </summary>
        public string SinceTimeFromSeconds { get; set; }

        /// <summary>
        /// Non-negative fractions of a second at nanosecond resolution. Negative
        /// second values with fractions must still have non-negative nanos values
        /// that count forward in time.Must be from 0 to 999,999,999
        /// inclusive.This field may be limited in precision depending on context.
        /// </summary>
        public int SinceTimeFromNanos { get; set; }

        public string TailLines { get; set; }

        public bool Follow { get; set; }

        public string UntilTime { get; set; }

        public string Filter { get; set; }

        public string Kind { get; set; }

        public string Group { get; set; }

        public string ResourceName { get; set; }

        public bool Previous { get; set; }

        public string AppNamespace { get; set; }

        public string Project { get; set; }
    }

}
