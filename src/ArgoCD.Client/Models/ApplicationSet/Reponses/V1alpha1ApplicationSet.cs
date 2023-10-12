using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using ArgoCD.Client.Models.Project.Responses;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// ApplicationSet is a set of Application resources +genclient +genclient:noStatus +k8s:deepcopy-gen:interfaces=k8s.io/apimachinery/pkg/runtime.Object +kubebuilder:resource:path=applicationsets,shortName=appset;appsets +kubebuilder:subresource:status
    /// </summary>
    public  class V1alpha1ApplicationSet
    {

 
        public V1ObjectMeta Metadata { get; set; }


        public V1alpha1ApplicationSetSpec Spec { get; set; }

        public V1alpha1ApplicationSetStatus Status { get; set; }


    }
}
