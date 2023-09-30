using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.GPKKey.Requests
{
    public sealed class CreateGPKKeyOptions
    {
        public CreateGPKKeyOptions() { }
        /// <summary>
        /// Whether to upsert already existing public keys.
        /// </summary>
        public bool Upsert { get; set; }
    }
}
