using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.GPKKey.Responses
{
    /// <summary>
    /// V1alpha1GnuPGPublicKeyList is a collection of GnuPGPublicKey objects
    /// </summary>
    public sealed class V1alpha1GnuPGPublicKeyList
    {
        /// <summary>
        /// GnuPGPublicKey is a representation of a GnuPG public key
        /// </summary>
        public V1alpha1GnuPGPublicKey[] Items { get; set; }

        /// <summary>
        /// ListMeta describes metadata that synthetic resources must have, including lists and
        /// various status objects.A resource may have only one of {ObjectMeta, ListMeta
        /// </summary>
        public V1ListMeta MetaData { get; set; }
    }
}
