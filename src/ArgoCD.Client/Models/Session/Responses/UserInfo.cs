using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Session.Responses
{
    /// <summary>
    /// The current user's userInfo info
    /// </summary>
    public class UserInfo
    {
        public string[] Groups { get; set; }

        public string Iss { get; set; }

        public bool LoggedIn { get; set; }

        public string Username { get; set; }


    }
}
