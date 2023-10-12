using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ResourceRef
    {
        public V1alpha1ResourceRef() { }


        public string Group { get; set; }


        public string Kind { get; set; }

  
        public string Name { get; set; }


        public string VarNamespace { get; set; }


        public string Uid { get; set; }


        public string VarVersion { get; set; }

    }
}
