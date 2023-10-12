using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1HostInfo
    {

        public string Name { get; set; }

        public V1alpha1HostResourceInfo[] ResourcesInfo { get; set; }

        public V1NodeSystemInfo[] SystemInfo { get; set; }
    }
}
