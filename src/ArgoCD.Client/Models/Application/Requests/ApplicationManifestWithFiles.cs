using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Requests
{
    public class ApplicationManifestWithFiles
    {

        public string AppNamespace { get; set; }

        public string Checksum { get; set; }


        public string Name { get; set; }


        public string Project { get; set; }
    }
}
