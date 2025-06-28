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

namespace ArgoCD.Client.Models.Certificate.Reponses
{
    /// <summary>
    /// A RepositoryCertificate is either SSH known hosts entry or TLS certificate
    /// </summary>
    public class V1alpha1RepositoryCertificate
    {
        /// <summary>
        /// CertData contains the actual certificate data, dependent on the certificate type
        /// </summary>
        public string CertData { get; set; }

        /// <summary>
        ///  CertInfo will hold additional certificate info, depdendent on the certificate type (e.g. SSH fingerprint, X509 CommonName)
        /// </summary>
        public string CertInfo { get; set; }

        /// <summary>
        /// CertSubType specifies the sub type of the cert, i.e. "ssh-rsa"
        /// </summary>
        public string CertSubType { get; set; }

        /// <summary>
        /// CertType specifies the type of the certificate - currently one of "https" or "ssh"
        /// </summary>
        public string CertType { get; set; }

        /// <summary>
        ///  ServerName specifies the DNS name of the server this certificate is intended for
        /// </summary>
        public string ServerName { get; set; }

    }
}
