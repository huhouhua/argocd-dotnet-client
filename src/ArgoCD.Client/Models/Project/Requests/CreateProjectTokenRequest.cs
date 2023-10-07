using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Requests
{
    /// <summary>
    /// CreateProjectTokenRequest defines project token creation parameters.
    /// </summary>
    public class CreateProjectTokenRequest
    {
        public string Description { get; set; }

        /// <summary>
        /// expiresIn represents a duration in seconds
        /// </summary>
        public string ExpiresIn { get; set; }

        public string Id { get; set; }


        public string Project { get; set; }

        public string Role { get; set; }
    }
}
