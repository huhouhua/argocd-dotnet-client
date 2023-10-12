using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationMatchExpression
    {

        public string Key { get; set; }

        public string VarOperator { get; set; }

        public List<string> Values { get; set; }
    }
}
