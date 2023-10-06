using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Responses
{
    public class RepositoryRepoApps
    {
        public RepositoryRepoApps() { }

        /// <summary>
        /// AppInfo contains application type and app file path
        /// </summary>
        public RepositoryAppInfo[] Items { get; set; }
    }
}
