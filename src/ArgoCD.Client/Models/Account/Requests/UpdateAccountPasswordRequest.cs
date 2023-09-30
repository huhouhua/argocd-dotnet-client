using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Account.Requests
{
    public sealed class UpdateAccountPasswordRequest
    {
        public string CurrentPassword { get; set; }

        public string Name { get; set; }

        public string NewPassword { get; set; }
    }
}
