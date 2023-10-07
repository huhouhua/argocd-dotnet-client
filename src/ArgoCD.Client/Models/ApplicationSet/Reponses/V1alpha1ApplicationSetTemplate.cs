using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSetTemplate
    {
        public V1alpha1ApplicationSetTemplateMeta Metadata { get; set; }

        public string Spec { get; set; }
    }
}
