using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ResourceAction
    {

        public bool Disabled { get; set; }

 
        public string DisplayName { get; set; }


        public string IconClass { get; set; }


        public string Name { get; set; }


        public V1alpha1ResourceActionParam[] VarParams { get; set; }

    }
}
