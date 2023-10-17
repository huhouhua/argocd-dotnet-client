using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.Application.Reponses;

namespace ArgoCD.Client.Internal.Http
{
    internal  class RuntimeError
    {
        public int Code { get; set; }

        public ProtobufAny[] Details { get; set; }

        public string Error { get; set; }

        public string Message { get; set; }
    }
}
