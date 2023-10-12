using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSetStatus
    {
        public V1alpha1ApplicationSetStatus() { }


        public List<V1alpha1ApplicationSetApplicationStatus> ApplicationStatus { get; set; }

  
        public List<V1alpha1ApplicationSetCondition> Conditions { get; set; }

    
    }
}
