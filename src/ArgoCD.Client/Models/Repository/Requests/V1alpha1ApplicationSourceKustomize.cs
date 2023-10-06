using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public class V1alpha1ApplicationSourceKustomize
    {
        public V1alpha1ApplicationSourceKustomize()
        {

        }

        /// <summary>
        /// CommonAnnotations is a list of additional annotations to add to rendered manifests
        /// </summary>
        public string[] CommonAnnotations { get; set; }

        /// <summary>
        /// CommonAnnotationsEnvsubst specifies whether to apply env variables substitution for annotation values
        /// </summary>
        public bool CommonAnnotationsEnvsubst { get; set; }

        /// <summary>
        /// CommonLabels is a list of additional labels to add to rendered manifests
        /// </summary>
        public string[] CommonLabels { get; set; }

        /// <summary>
        /// ForceCommonAnnotations specifies whether to force applying common annotations to resources for Kustomize apps
        /// </summary>
        public bool ForceCommonAnnotations { get; set; }

        /// <summary>
        /// ForceCommonLabels specifies whether to force applying common labels to resources for Kustomize apps
        /// </summary>
        public bool ForceCommonLabels { get; set; }

        /// <summary>
        /// Images is a list of Kustomize image override specifications
        /// </summary>
        public string[] Images { get; set; }

        /// <summary>
        ///  NamePrefix is a prefix appended to resources for Kustomize apps
        /// </summary>
        public string NamePrefix { get; set; }

        /// <summary>
        /// NameSuffix is a suffix appended to resources for Kustomize apps
        /// </summary>
        public string NameSuffix { get; set; }

        /// <summary>
        /// Namespace sets the namespace that Kustomize adds to all resources
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Replicas is a list of Kustomize Replicas override specifications
        /// </summary>
        public V1alpha1KustomizeReplica[] Replicas { get; set; }

        /// <summary>
        ///  Version controls which version of Kustomize to use for rendering manifests
        /// </summary>
        public string Version { get; set; }

    }
}
