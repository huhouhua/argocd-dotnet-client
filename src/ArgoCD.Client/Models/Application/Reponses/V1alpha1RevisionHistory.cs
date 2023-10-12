using ArgoCD.Client.Models.ApplicationSet.Reponses;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1RevisionHistory
    {

        public V1Time DeployStartedAt { get; set; }

     
        public V1Time DeployedAt { get; set; }

        public string Id { get; set; }

        public string Revision { get; set; }

        public string[] Revisions { get; set; }


        public V1alpha1ApplicationSource Source { get; set; }


        public V1alpha1ApplicationSource[] Sources { get; set; }
    }
}
