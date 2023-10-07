using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1alpha1OrphanedResourcesMonitorSettings
    {

        /// <summary>
        /// Ignore contains a list of resources that are to be excluded from orphaned resources monitoring
        /// </summary>
        public V1alpha1OrphanedResourceKey[] Ignore { get; set; }

        /// <summary>
        /// Warn indicates if warning condition should be created for apps which have orphaned resources
        /// </summary>
        public bool Warn { get; set; }

    }

 
}
