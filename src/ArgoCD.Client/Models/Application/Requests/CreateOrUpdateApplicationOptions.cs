using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public sealed class CreateApplicationOptions
    {
        public bool Upsert { get; set; }

        public bool Validate { get; set; }
    }
}
