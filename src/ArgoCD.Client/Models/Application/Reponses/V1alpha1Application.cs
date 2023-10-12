using ArgoCD.Client.Models.ApplicationSet.Reponses;
using ArgoCD.Client.Models.Project.Responses;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1Application
    {
 
        public V1ObjectMeta Metadata { get; set; }


        public V1alpha1Operation Operation { get; set; }


        public V1alpha1ApplicationSpec Spec { get; set; }


        public V1alpha1ApplicationStatus Status { get; set; }


    }
}
