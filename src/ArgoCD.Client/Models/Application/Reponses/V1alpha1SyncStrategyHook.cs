namespace ArgoCD.Client.Models.Application.Reponses
{
    /// <summary>
    /// SyncStrategyHook will perform a sync using hooks annotations. If no hook annotation is specified falls back to &#x60;kubectl apply&#x60;.
    /// </summary>
    public class V1alpha1SyncStrategyHook
    {
        public V1alpha1SyncStrategyApply SyncStrategyApply { get; set; }

    }
}
