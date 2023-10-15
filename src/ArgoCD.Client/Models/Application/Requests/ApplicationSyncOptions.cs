using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Requests
{
    public class ApplicationSyncOptions
    {

        public List<string> Items { get; set; }
    }
}
