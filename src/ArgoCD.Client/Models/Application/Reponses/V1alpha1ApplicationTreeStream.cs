using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ApplicationTreeStream
    {

        public RuntimeStreamError Error { get; set; }


        public V1alpha1ApplicationTree Result { get; set; }

    }
}
