using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1alpha1JWTToken
    {

        public string Exp { get; set; }
        public string Iat { get; set; }
        public string Id { get; set; }
    }
}
