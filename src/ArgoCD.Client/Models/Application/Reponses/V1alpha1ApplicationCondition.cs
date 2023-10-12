using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ApplicationCondition
    {

        public V1Time LastTransitionTime { get; set; }


        public string Message { get; set; }

        public string Type { get; set; }
    }
}
