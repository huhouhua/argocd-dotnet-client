using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// ApplicationSetList contains a list of ApplicationSet +k8s:deepcopy-gen:interfaces=k8s.io/apimachinery/pkg/runtime.Object +kubebuilder:object:root=true
    /// </summary>
    public  class V1alpha1ApplicationSetList
    {
        public List<V1alpha1ApplicationSet> Items { get; set; }

        public V1ListMeta Metadata { get; set; }
    }
}
