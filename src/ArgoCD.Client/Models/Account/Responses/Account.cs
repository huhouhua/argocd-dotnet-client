using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Account.Responses
{
    public sealed class Account
    {
        public string[] Capabilities { get; set; }

        public bool Enabled { get; set; }

        public string Name { get; set; }

        public AccountToken[] Tokens { get; set; }
    }
}
