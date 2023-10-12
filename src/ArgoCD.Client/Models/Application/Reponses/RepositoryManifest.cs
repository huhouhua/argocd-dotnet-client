using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class RepositoryManifest
    {

        public string[] Manifests { get; set; }


        public string VarNamespace { get; set; }


        public string Revision { get; set; }


        public string Server { get; set; }

   
        public string SourceType { get; set; }


        public string VerifyResult { get; set; }
    }
}
