using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1TagFilter
    {

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
