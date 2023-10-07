using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    /// <summary>
    /// ProjectToken wraps the created token or returns an empty string if deleted
    /// </summary>
    public class ProjectToken
    {
        public string Token { get; set; }
    }
}
