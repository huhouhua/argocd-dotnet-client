namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1OperationState
    {

        public V1Time FinishedAt { get; set; }

        /// <summary>
        /// Message holds any pertinent messages when attempting to perform operation (typically errors).
        /// </summary>
        public string Message { get; set; }


        public V1alpha1Operation Operation { get; set; }

        public string Phase { get; set; }

        public string RetryCount { get; set; }


        public V1Time StartedAt { get; set; }


        public V1alpha1SyncOperationResult SyncResult { get; set; }
    }
}
