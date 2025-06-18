using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public  class V1alpha1ApplicationPreservedFields
    {

        public V1alpha1ApplicationPreservedFields()
        {
           
        }


        public List<string> Annotations { get; set; }


    }
}
