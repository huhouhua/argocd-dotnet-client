using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Account.Responses
{
    public class AccountToken
    {
        public long ExpiresAt { get; set; }

        public string Id { get; set; }

        public long IssuedAt { get; set; }
    }
}
