using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.RepoCreds.Requests
{
    public sealed class CreateRepoCredsOptions
    {
        public CreateRepoCredsOptions()
        {

        }

        /// <summary>
        /// Whether to create in upsert mode.
        /// </summary>
        public bool Upsert { get; set; }


    }
}
