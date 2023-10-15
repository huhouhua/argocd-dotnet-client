using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using ArgoCD.Client.Models.Application.Reponses;
using ArgoCD.Client.Models.ApplicationSet.Reponses;

namespace ArgoCD.Client.Models.Application.Requests
{
    public  class ApplicationSyncRequest
    {
 
        public string AppNamespace { get; set; }

      
        public bool DryRun { get; set; }


        public List<V1alpha1Info> Infos { get; set; }

        public List<string> Manifests { get; set; }


        public string Name { get; set; }


        public string Project { get; set; }


        public bool Prune { get; set; }

        public List<V1alpha1SyncOperationResource> Resources { get; set; }


        public V1alpha1RetryStrategy RetryStrategy { get; set; }

 
        public string Revision { get; set; }


        public V1alpha1SyncStrategy Strategy { get; set; }


        public ApplicationSyncOptions SyncOptions { get; set; }
    }
}
