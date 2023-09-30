using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Session.Requests
{
    /// <summary>
    ///CreateSessionRequest is for logging in
    /// </summary>
    public sealed class CreateSessionRequest
    {
        public string Password { get; set; }

        public string Token { get; set; }

        public string UserName { get; set; }
    }
}
