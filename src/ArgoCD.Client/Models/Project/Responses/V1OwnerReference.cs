using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1OwnerReference
    {
        public V1OwnerReference() { }

        /// <summary>
        /// API version of the referent.
        /// </summary>
        public string ApiVersion { get; set; }


        /// <summary>
        /// If true, AND if the owner has the "foregroundDeletion" finalizer, then the owner cannot be deleted
        /// from the key-value store until this reference is removed.
        /// Defaults to false. To set this field, a user needs "delete" permission of the owner,
        /// otherwise 422 (Unprocessable Entity) will be returned. +optional
        /// </summary>
        public bool BlockOwnerDeletion { get; set; }


        /// <summary>
        /// If true, this reference points to the managing controller. +optional
        /// </summary>
        public bool Controller { get; set; }


        /// <summary>
        /// Kind of the referent. More info: https://git.k8s.io/community/contributors/devel/sig-architecture/api-conventions.md#types-kinds
        /// </summary>
        public string Kind { get; set; }


        /// <summary>
        /// Name of the referent. More info: http://kubernetes.io/docs/user-guide/identifiers#names
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// UID of the referent. More info: http://kubernetes.io/docs/user-guide/identifiers#uids
        /// </summary>
        public string Uid { get; set; }
    }
}
