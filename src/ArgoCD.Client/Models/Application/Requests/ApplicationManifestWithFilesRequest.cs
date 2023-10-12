using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.Project.Responses;

namespace ArgoCD.Client.Models.Application.Requests
{
    public class ApplicationManifestWithFilesRequest
    {
        public ApplicationManifestWithFilesRequest() { }

        public V1ObjectMeta Chunk { get; set; }

        public ApplicationManifestWithFiles Query { get; set; }

    }
}
