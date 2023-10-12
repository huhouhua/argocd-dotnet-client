using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Application.Requests
{
    public class ApplicationFileChunk
    {
        public byte[] Chunk { get; set; }
    }
}
