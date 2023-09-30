using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Account.Requests
{
    public sealed class CreateAccountTokenRequest
    {
        /// <summary>
        /// expiresIn represents a duration in seconds
        /// </summary>
        public string ExpiresIn { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
