using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ResourceStatus
    {

        public string Group { get; set; }

 
        public V1alpha1HealthStatus Health { get; set; }


        public bool Hook { get; set; }

        public string Kind { get; set; }


        public string Name { get; set; }


        public string VarNamespace { get; set; }


        public bool RequiresPruning { get; set; }

        public string Status { get; set; }


        public string SyncWave { get; set; }


        public string VarVersion { get; set; }
    }
}
