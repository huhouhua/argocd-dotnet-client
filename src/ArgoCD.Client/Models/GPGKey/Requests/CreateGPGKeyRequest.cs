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

namespace ArgoCD.Client.Models.GPKKey.Requests
{
    /// <summary>
    /// CreateGPGRequest is a representation of a GnuPG public key
    /// </summary>
    public sealed class CreateGPGKeyRequest
    {
        /// <summary>
        /// Fingerprint is the fingerprint of the key
        /// </summary>
        public string Fingerprint { get; set; }

        /// <summary>
        /// KeyData holds the raw key data, in base64 encoded format
        /// </summary>
        public string KeyData { get; set; }
        /// <summary>
        /// KeyID specifies the key ID, in hexadecimal string format
        /// </summary>
        public string KeyID { get; set; }

        /// <summary>
        /// Owner holds the owner identification, e.g. a name and e-mail address
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// SubType holds the key's sub type (e.g. rsa4096)
        /// </summary>
        public string SubType { get; set; }

        /// <summary>
        /// Trust holds the level of trust assigned to this key
        /// </summary>
        public string Trust { get; set; }
    }
}
