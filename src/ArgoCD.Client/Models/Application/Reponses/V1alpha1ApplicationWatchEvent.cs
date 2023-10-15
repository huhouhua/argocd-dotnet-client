using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ArgoCD.Client.Models.Application.Reponses
{
    /// <summary>
    /// ApplicationWatchEvent contains information about application change.
    /// </summary>
    public class V1alpha1ApplicationWatchEvent
    {

        public V1alpha1Application Application { get; set; }


        public string Type { get; set; }

    }
}
