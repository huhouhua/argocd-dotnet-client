using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSetTemplateMeta
    {

        public Dictionary<string, string> Annotations { get; set; }

   
        public List<string> Finalizers { get; set; }


        public Dictionary<string, string> Labels { get; set; }


        public string Name { get; set; }

        public string VarNamespace { get; set; }
    }
}
