using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public class AppDetailsRequest
    {
        public AppDetailsRequest() { }

        public string AppName { get; set; }

        public string AppProject { get; set; }

        /// <summary>
        /// ApplicationSource contains all required information about the source of an application
        /// </summary>
        public V1alpha1ApplicationSource Source { get; set; }
    }
}
