using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ApplicationTree
    {
        public V1alpha1ApplicationTree() { }

        public V1alpha1HostInfo[] Hosts { get; set; }

        /// <summary>
        /// Nodes contains list of nodes which either directly managed by the application and children of directly managed nodes.
        /// </summary>

        public V1alpha1ResourceNode[] Nodes { get; set; }

        /// <summary>
        /// OrphanedNodes contains if or orphaned nodes: nodes which are not managed by the app but in the same namespace. List is populated only if orphaned resources enabled in app project.
        /// </summary>
        public V1alpha1ResourceNode[] OrphanedNodes { get; set; }


    }
}
