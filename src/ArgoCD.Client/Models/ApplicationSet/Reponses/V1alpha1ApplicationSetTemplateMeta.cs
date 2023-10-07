using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSetTemplateMeta
    {

        public object Annotations { get; set; }

        public string[] Finalizers { get; set; }

        public object Labels { get; set; }

        public string Name { get; set; }

        public string Namespace { get; set; }
    }
}
