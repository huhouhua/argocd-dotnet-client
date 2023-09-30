using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Settings.Responses
{
    public  sealed class ClusterHelp
    {
        /// <summary>
        ///the URLs for downloading argocd binaries
        /// </summary>
        public string[] BinaryUrls { get; set; }

        /// <summary>
        /// the text for getting chat help, defaults to "Chat now!"
        /// </summary>
        public string ChatText { get; set; }

        /// <summary>
        /// the URL for getting chat help, this will typically be your Slack channel for support
        /// </summary>
        public string ChatUrl { get; set; }
    }
}
