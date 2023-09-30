using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Settings.Responses
{
    public sealed class V1alpha1Command
    {
        public string[] Args { get; set; }
        public string[] Command { get; set; }
    }
}
