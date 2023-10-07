using System;
using System.Collections.Generic;
using System.Text;
using static ArgoCD.Client.Models.Project.Responses.V1alpha1AppProjectList;

namespace ArgoCD.Client.Models.Project.Responses
{
    public  class V1alpha1AppProject
    {
        public V1alpha1AppProject() { }

        /// <summary>
        /// ObjectMeta is metadata that all persisted resources must have, which includes all objects
        /// users must create.
        /// </summary>

        public V1ObjectMeta Metadata { get; set; }

        /// <summary>
        /// AppProjectSpec is the specification of an AppProject
        /// </summary>
        public V1alpha1AppProjectSpec Spec { get; set; }

        /// <summary>
        /// AppProjectStatus contains status information for AppProject CRs
        /// </summary>
        public V1alpha1AppProjectStatus Status { get; set; }
    }
}
