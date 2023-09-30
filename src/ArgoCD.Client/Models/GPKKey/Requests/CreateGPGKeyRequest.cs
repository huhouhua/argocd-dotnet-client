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
