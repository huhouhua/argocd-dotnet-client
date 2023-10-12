using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public  class V1alpha1ApplicationSetRolloutStep
    {
        public List<V1alpha1ApplicationMatchExpression> MatchExpressions { get; set; }
        public IntstrIntOrString MaxUpdate { get; set; }

    }
}
