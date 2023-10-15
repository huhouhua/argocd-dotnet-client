using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class ApplicationSyncWindows
    {

        public ApplicationSyncWindow[] ActiveWindows { get; set; }

   
        public ApplicationSyncWindow[] AssignedWindows { get; set; }


        public bool CanSync { get; set; }
    }
}
