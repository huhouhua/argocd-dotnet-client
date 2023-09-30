using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Account.Responses
{
    public class AccountToken
    {
        public string ExpiresAt { get; set; }

        public string Id { get; set; }

        public string IssuedAt { get; set; }
    }
}
