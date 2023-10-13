using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public  class ApplicationLogEntryStream
    {

        public RuntimeStreamError Error { get; set; }

        public ApplicationLogEntry Result { get; set; }
    }
}
