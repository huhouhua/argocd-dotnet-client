using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class ApplicationLinks
    {
        public ApplicationLinks() { }

        public ApplicationLinkInfo[] Items { get; set; }
    }
}
