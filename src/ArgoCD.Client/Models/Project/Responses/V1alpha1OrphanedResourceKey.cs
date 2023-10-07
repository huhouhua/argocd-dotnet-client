using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1alpha1OrphanedResourceKey
    {

        public string Group { get; set; }
        public string Kind { get; set; }
        public string Name { get; set; }
    }
}
