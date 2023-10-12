using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ResourceResult
    {

        public string Group { get; set; }

        /// <summary>
        /// HookPhase contains the state of any operation associated with this resource OR hook This can also contain values for non-hook resources.
        /// </summary>
        public string HookPhase { get; set; }


        public string HookType { get; set; }


        public string Kind { get; set; }


        public string Message { get; set; }


        public string Name { get; set; }


        public string VarNamespace { get; set; }


        public string Status { get; set; }


        public string SyncPhase { get; set; }


        public string VarVersion { get; set; }
    }
}
