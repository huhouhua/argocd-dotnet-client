using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public class V1alpha1JsonnetVar
    {
        public bool Code { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
