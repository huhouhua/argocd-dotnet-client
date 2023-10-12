using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;
using ArgoCD.Client.Models.ApplicationSet.Reponses;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ComparedTo
    {

        public V1alpha1ApplicationDestination Destination { get; set; }


        public List<V1alpha1ResourceIgnoreDifferences> IgnoreDifferences { get; set; }


        public V1alpha1ApplicationSource Source { get; set; }

 
        public List<V1alpha1ApplicationSource> Sources { get; set; }
    }
}
