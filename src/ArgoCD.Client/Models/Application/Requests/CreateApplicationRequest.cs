using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.Application.Reponses;

namespace ArgoCD.Client.Models.Application.Requests
{
    public class CreateApplicationRequest
    {
        public CreateApplicationRequest() { }

        public V1alpha1Application Application { get; set; }
    }
}
