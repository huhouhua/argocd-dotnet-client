using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class ProjectGlobalProjects
    {
        public V1alpha1AppProject[] Items { get; set; }
    }
}
