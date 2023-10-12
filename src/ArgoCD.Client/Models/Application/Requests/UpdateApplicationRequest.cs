using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.Application.Reponses;

namespace ArgoCD.Client.Models.Application.Requests
{
    public class UpdateApplicationRequest
    {
        public UpdateApplicationRequest() { }

        /// <summary>
        /// Name must be unique within a namespace. Is required when creating resources, although
        /// some resources may allow a client to request the generation of an appropriate name
        /// automatically.Name is primarily intended for creation idempotence and configuration definition.
        /// Cannot be updated. More info: http://kubernetes.io/docs/user-guide/identifiers#names +optional
        /// </summary>
        public string Name { get; set; }


        public V1alpha1Application Application { get; set; }

    }
}
