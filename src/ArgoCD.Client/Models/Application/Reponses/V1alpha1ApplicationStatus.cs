namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1ApplicationStatus
    {

        public V1alpha1ApplicationCondition[] Conditions { get; set; }


        public string ControllerNamespace { get; set; }


        public V1alpha1HealthStatus Health { get; set; }


        public V1alpha1RevisionHistory[] History { get; set; }


        public V1Time ObservedAt { get; set; }

  
        public V1alpha1OperationState OperationState { get; set; }


        public V1Time ReconciledAt { get; set; }


        public string ResourceHealthSource { get; set; }


        public V1alpha1ResourceStatus[] Resources { get; set; }


        public string SourceType { get; set; }


        public string[] SourceTypes { get; set; }

  
        public V1alpha1ApplicationSummary Summary { get; set; }


        public V1alpha1SyncStatus Sync { get; set; }
    }
}
