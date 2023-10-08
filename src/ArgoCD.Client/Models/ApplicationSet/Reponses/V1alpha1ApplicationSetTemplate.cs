using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSetTemplate
    {
        /// <summary>
        /// ApplicationSetTemplateMeta represents the Argo CD application fields that may
        /// be used for Applications generated from the ApplicationSet(based on metav1.ObjectMeta)
        /// </summary>
        public V1alpha1ApplicationSetTemplateMeta Metadata { get; set; }

        /// <summary>
        /// ApplicationSpec represents desired application state. Contains link to repository with application definition and additional parameters link definition revision.
        /// </summary>
        public V1alpha1ApplicationSpec Spec { get; set; }
    }
}
