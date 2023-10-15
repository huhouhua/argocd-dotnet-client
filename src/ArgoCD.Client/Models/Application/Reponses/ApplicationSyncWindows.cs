using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class ApplicationSyncWindows
    {

        public ApplicationApplicationSyncWindow[] ActiveWindows { get; set; }

   
        public ApplicationApplicationSyncWindow[] AssignedWindows { get; set; }


        public bool CanSync { get; set; }
    }
}
