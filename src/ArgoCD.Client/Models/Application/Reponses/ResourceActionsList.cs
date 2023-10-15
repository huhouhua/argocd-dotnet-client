using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class ResourceActionsList
    {
        public V1alpha1ResourceAction[] Actions { get; set; }
    }
}
