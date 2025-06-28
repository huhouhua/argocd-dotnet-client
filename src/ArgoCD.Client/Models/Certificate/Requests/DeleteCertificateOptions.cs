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

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Certificate.Requests
{
    public sealed class DeleteCertificateOptions
    {
        /// <summary>
        /// A file-glob pattern (not regular expression) the host name has to match.
        /// </summary>
        public string HostNamePattern { get; set; }

        /// <summary>
        /// The type of the certificate to match (ssh or https).
        /// </summary>
        public string CertType { get; set; }

        /// <summary>
        /// The sub type of the certificate to match (protocol dependent, usually only used for ssh certs).
        /// </summary>
        public string CertSubType { get; set; }
    }
}
