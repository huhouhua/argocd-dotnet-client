using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.Project.Responses;

namespace ArgoCD.Client.Models.Project.Requests
{
    public class UpdateProjectRequest
    {
        public V1alpha1AppProject Project { get; set; }
    }
}
