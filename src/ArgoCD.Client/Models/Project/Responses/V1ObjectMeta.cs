using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using static System.Net.Mime.MediaTypeNames;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1ObjectMeta
    {
        public V1ObjectMeta() { }

        /// <summary>
        /// Annotations is an unstructured key value map stored with a resource that may be
        /// set by external tools to store and retrieve arbitrary metadata.They are not
        /// queryable and should be preserved when modifying objects.
        /// More info: http://kubernetes.io/docs/user-guide/annotations +optional
        /// </summary>
        public List<string> Annotations { get; set; }

        /// <summary>
        /// The name of the cluster which the object belongs to. This is used to distinguish resources with same name
        /// and namespace in different clusters. This field is not set anywhere right now and apiserver is going to
        /// ignore it if set in create or update request. +optional
        /// </summary>
        public string ClusterName { get; set; }


        public V1Time CreationTimestamp { get; set; }

        /// <summary>
        /// Number of seconds allowed for this object to gracefully terminate before it will be removed from the system.
        /// Only set when deletionTimestamp is also set. May only be shortened. Read-only. +optional
        /// </summary>
        public string DeletionGracePeriodSeconds { get; set; }


        public V1Time DeletionTimestamp { get; set; }

        /// <summary>
        /// Must be empty before the object is deleted from the registry. Each entry
        /// is an identifier for the responsible component that will remove the entry
        /// from the list.If the deletionTimestamp of the object is non-nil, entries in this list can only be removed.
        /// Finalizers may be processed and removed in any order.Order is NOT enforced
        /// because it introduces significant risk of stuck finalizers.
        /// finalizers is a shared field, any actor with permission can reorder it.
        /// If the finalizer list is processed in order, then this can lead to a situation
        /// in which the component responsible for the first finalizer in the list is
        /// waiting for a signal (field value, external system, or other) produced by a
        /// component responsible for a finalizer later in the list, resulting in a deadlock.
        /// Without enforced ordering finalizers are free to order amongst themselves and
        /// are not vulnerable to ordering changes in the list. +optional +patchStrategy= merge
        /// </summary>
        public List<string> Finalizers { get; set; }

        /// <summary>
        /// GenerateName is an optional prefix, used by the server, to generate a unique
        /// name ONLY IF the Name field has not been provided.
        /// If this field is used, the name returned to the client will be different
        /// than the name passed.This value will also be combined with a unique suffix.
        /// The provided value has the same validation rules as the Name field,
        /// and may be truncated by the length of the suffix required to make the value
        /// unique on the server.
        /// If this field is specified and the generated name exists, the server will
        /// NOT return a 409 - instead, it will either return 201 Created or 500 with Reason
        /// ServerTimeout indicating a unique name could not be found in the time allotted, and the client
        /// should retry (optionally after the time indicated in the Retry-After header).
        ///  Applied only if Name is not specified.
        ///  More info: https://git.k8s.io/community/contributors/devel/sig-architecture/api-conventions.md#idempotency +optional
        /// </summary>
        public string GenerateName { get; set; }

        /// <summary>
        ///  A sequence number representing a specific generation of the desired state. Populated by the system. Read-only. +optional
        /// </summary>
        public string Generation { get; set; }

        /// <summary>
        /// Map of string keys and values that can be used to organize and categorize
        /// (scope and select) objects.May match selectors of replication controllers and services.
        /// More info: http://kubernetes.io/docs/user-guide/labels +optional
        /// </summary>
        public Dictionary<string, string> Labels { get; set; }


        /// <summary>
        /// ManagedFields maps workflow-id and version to the set of fields
        /// that are managed by that workflow.This is mostly for internal
        /// housekeeping, and users typically shouldn't need to set or
        /// understand this field.A workflow can be the user's name, a
        /// controller's name, or the name of a specific apply path like
        /// "ci-cd". The set of fields is always in the version that the
        /// workflow used when modifying the object.
        /// </summary>
        public List<V1ManagedFieldsEntry> ManagedFields { get; set; }



        /// <summary>
        /// Name must be unique within a namespace. Is required when creating resources,
        /// although some resources may allow a client to request the generation of an appropriate name automatically.
        /// Name is primarily intended for creation idempotence and configuration definition. Cannot be updated.
        /// More info: http://kubernetes.io/docs/user-guide/identifiers#names +optional
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Namespace defines the space within which each name must be unique. An empty namespace is
        /// equivalent to the "default" namespace, but "default" is the canonical representation.
        /// Not all objects are required to be scoped to a namespace - the value of this field for
        /// those objects will be empty.
        /// Must be a DNS_LABEL.
        /// Cannot be updated.
        /// More info: http://kubernetes.io/docs/user-guide/namespaces +optional
        /// </summary>
        public string NameSpace { get; set; }


        /// <summary>
        /// List of objects depended by this object. If ALL objects in the list have
        /// been deleted, this object will be garbage collected.If this object is managed by a controller,
        /// then an entry in this list will point to this controller, with the controller field set to true.
        /// There cannot be more than one managing controller. +optional  +patchMergeKey= uid  + patchStrategy = merge
        /// </summary>
        public List<V1OwnerReference> OwnerReferences { get; set; }


        /// <summary>
        /// An opaque value that represents the internal version of this object that can
        /// be used by clients to determine when objects have changed.May be used for optimistic
        /// concurrency, change detection, and the watch operation on a resource or set of resources.
        /// Clients must treat these values as opaque and passed unmodified back to the server.
        /// They may only be valid for a particular resource or set of resources. Populated by the system.
        /// Read-only. Value must be treated as opaque by clients and .
        /// More info: https://git.k8s.io/community/contributors/devel/sig-architecture/api-conventions.md#concurrency-control-and-consistency +optional
        /// </summary>
        public string ResourceVersion { get; set; }


        /// <summary>
        /// SelfLink is a URL representing this object.  Populated by the system.
        /// Read-only.
        /// DEPRECATED
        /// Kubernetes will stop propagating this field in 1.20 release and the field is planned
        /// to be removed in 1.21 release.
        /// +optional
        /// </summary>
        public string SelfLink { get; set; }


        /// <summary>
        /// UID is the unique in time and space value for this object. It is typically generated by
        /// the server on successful creation of a resource and is not allowed to change on PUT
        /// operations. Populated by the system. Read-only.
        /// More info: http://kubernetes.io/docs/user-guide/identifiers#uids +optional
        /// </summary>
        public string Uid { get; set; }
    }
}
