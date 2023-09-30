using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.GPKKey.Requests
{
    public sealed class DeleteGPGKeyOptions
    {
        public DeleteGPGKeyOptions()
        {

        }

        /// <summary>
        /// The GPG key ID to query for.
        /// </summary>
        public string KeyID { get; set; }
    }
}
