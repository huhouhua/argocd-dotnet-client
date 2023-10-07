using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1EventSource
    {
        public V1EventSource() { }

        /// <summary>
        /// Component from which the event is generated. +optional
        /// </summary>
        public string Component { get; set; }


        /// <summary>
        ///  Node name on which the event is generated. +optional
        /// </summary>
        public string Host { get; set; }
    }
}
