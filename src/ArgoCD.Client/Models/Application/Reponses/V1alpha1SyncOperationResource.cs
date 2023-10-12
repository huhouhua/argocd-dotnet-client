using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1SyncOperationResource
    {

        public string Group { get; set; }


        public string Kind { get; set; }


        public string Name { get; set; }

        public string VarNamespace { get; set; }
    }
}
