using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ApplicationList
    {

        public V1alpha1Application[] Items { get; set; }


        public V1ListMeta Metadata { get; set; }
    }
}
