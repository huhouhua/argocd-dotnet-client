using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1SyncStatus
    {

        public V1alpha1ComparedTo ComparedTo { get; set; }

 
        public string Revision { get; set; }


        public List<string> Revisions { get; set; }

        public string Status { get; set; }
    }
}
