using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1PortStatus
    {

        public string Error { get; set; }

        public int Port { get; set; }


        public string Protocol { get; set; }
    }
}
