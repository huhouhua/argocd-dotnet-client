using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.GPKKey.Responses
{
    /// <summary>
    /// GnuPGPublicKey is Response to a public key creation request
    /// </summary>
    public class GnuPGPublicKey
    {

        /// <summary>
        /// GnuPGPublicKeyList is a collection of GnuPGPublicKey objects
        /// </summary>
        public V1alpha1GnuPGPublicKeyList Created { get; set; }

        /// <summary>
        /// List of key IDs that haven been skipped because they already exist on the server
        /// </summary>

        public string[] Skipped { get; set; }

    }
}
