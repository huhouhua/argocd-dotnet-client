using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{ 
    /// <summary>
    /// ApplicationSetStrategy configures how generated Applications are updated in sequence.
    /// </summary>
    public  class V1alpha1ApplicationSetStrategy 
    {


        public V1alpha1ApplicationSetRolloutStrategy RollingSync { get; set; }


        public string Type { get; set; }

    }
}
