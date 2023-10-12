using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;
using ArgoCD.Client.Models.ApplicationSet.Reponses;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1Operation
    {

        public V1alpha1Info[] Info { get; set; }


        public V1alpha1OperationInitiator InitiatedBy { get; set; }


        public V1alpha1RetryStrategy Retry { get; set; }


        public V1alpha1SyncOperation Sync { get; set; }
    }
}
