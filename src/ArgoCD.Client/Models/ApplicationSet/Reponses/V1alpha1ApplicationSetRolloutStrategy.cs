using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public  class V1alpha1ApplicationSetRolloutStrategy 
    {

        public List<V1alpha1ApplicationSetRolloutStep> Steps { get; set; }


    }
}
