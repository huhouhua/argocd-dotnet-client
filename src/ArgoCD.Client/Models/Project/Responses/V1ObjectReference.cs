using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1ObjectReference
    {
        public V1ObjectReference() { }

        /// <summary>
        /// API version of the referent. +optional
        /// </summary>
        public string ApiVersion { get; set; }


        /// <summary>
        /// If referring to a piece of an object instead of an entire object, this string should contain a
        /// valid JSON/Go field access statement, such as desiredState.manifest.containers[2]. For example,
        /// if the object reference is to a container within a pod, this would take on a value like: "spec.containers{name}"
        /// (where "name" refers to the name of the container that triggered the event) or if no container name is specified
        /// "spec.containers[2]" (container with index 2 in this pod). This syntax is chosen only to have some well-defined
        /// way of referencing a part of an object. TODO: this design is not final and this field is subject to change
        /// in the future. +optional
        /// </summary>
        public string FieldPath { get; set; }

        /// <summary>
        /// Kind of the referent. More info: https://git.k8s.io/community/contributors/devel/sig-architecture/api-conventions.md#types-kinds +optional
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Name of the referent. More info: https://kubernetes.io/docs/concepts/overview/working-with-objects/names/#names +optional
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Namespace of the referent. More info: https://kubernetes.io/docs/concepts/overview/working-with-objects/namespaces/ +optional
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Specific resourceVersion to which this reference is made, if any. More info: https://git.k8s.io/community/contributors/devel/sig-architecture/api-conventions.md#concurrency-control-and-consistency +optional
        /// </summary>
        public string ResourceVersion { get; set; }

        /// <summary>
        /// UID of the referent. More info: https://kubernetes.io/docs/concepts/overview/working-with-objects/names/#uids +optional
        /// </summary>
        public string Uid { get; set; }
    }
}
