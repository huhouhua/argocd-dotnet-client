using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static System.Net.WebRequestMethods;

namespace ArgoCD.Client.Models.Project.Responses
{
    /// <summary>
    /// Event is a report of an event somewhere in the cluster. Events
    /// have a limited retention time and triggers and messages may evolve
    /// with time. Event consumers should not rely on the timing of an event
    /// with a given Reason reflecting a consistent underlying trigger, or the
    /// continued existence of events with that Reason. Events should be
    /// treated as informative, best-effort, supplemental data.
    /// </summary>
    public class V1Event
    {
        public V1Event() { }


        /// <summary>
        /// What action was taken/failed regarding to the Regarding object. +optional
        /// </summary>
        public string Action { get; set; }


        /// <summary>
        /// The number of times this event has occurred. +optional
        /// </summary>
        public int Count { get; set; }


        /// <summary>
        /// The number of times this event has occurred. +optional
        /// </summary>
        public V1MicroTime EventTime { get; set; }


        public V1Time FirstTimestamp { get; set; }


        /// <summary>
        /// ObjectReference contains enough information to let you inspect or modify the referred object.
        /// ---New uses of this type are discouraged because of difficulty describing its usage when embedded in APIs.
        /// 1. Ignored fields.  It includes many fields which are not generally honored.For instance, ResourceVersion and FieldPath are both very rarely valid in actual usage.
        /// 2. Invalid usage help.It is impossible to add specific help for individual usage.  In most embedded usages, there are particular
        /// restrictions like, "must refer only to types A and B" or "UID not honored" or "name must be restricted". Those cannot be well described when embedded.
        /// 3. Inconsistent validation.  Because the usages are different, the validation rules are different by usage, which makes it hard for users to predict what will happen.
        /// 4. The fields are both imprecise and overly precise.  Kind is not a precise mapping to a URL.This can produce ambiguity
        /// during interpretation and require a REST mapping.In most cases, the dependency is on the group, resource tuple and the version of the actual struct is irrelevant.
        /// 5. We cannot easily change it.Because this type is embedded in many locations, updates to this type  will affect numerous schemas.Don't make new APIs embed an
        /// underspecified API type they do not control.Instead of using this type, create a locally provided and used type that is well-focused on your reference.
        /// For example, ServiceReferences for admission registration: https://github.com/kubernetes/api/blob/release-1.17/admissionregistration/v1/types.go#L533 .
        /// +k8s:deepcopy-gen:interfaces= k8s.io / apimachinery / pkg / runtime.Object+ structType = atomic
        /// </summary>
        public V1ObjectReference InvolvedObject { get; set; }

        public V1Time LastTimestamp { get; set; }

        /// <summary>
        /// A human-readable description of the status of this operation. TODO: decide on maximum length. +optional
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// ObjectMeta is metadata that all persisted resources must have, which includes all objects users must create.
        /// </summary>
        public V1ObjectMeta Metadata { get; set; }


        /// <summary>
        /// This should be a short, machine understandable string that gives the reason for the transition into the object's current status. TODO: provide exact specification for format. +optional
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// ObjectReference contains enough information to let you inspect or modify the referred object.
        /// ---New uses of this type are discouraged because of difficulty describing its usage when embedded in APIs.
        /// 1. Ignored fields.  It includes many fields which are not generally honored.For instance, ResourceVersion and FieldPath are both very rarely valid in actual usage.
        /// 2. Invalid usage help.It is impossible to add specific help for individual usage.  In most embedded usages, there are particular
        /// restrictions like, "must refer only to types A and B" or "UID not honored" or "name must be restricted". Those cannot be well described when embedded.
        /// 3. Inconsistent validation.  Because the usages are different, the validation rules are different by usage, which makes it hard for users to predict what will happen.
        /// 4. The fields are both imprecise and overly precise.  Kind is not a precise mapping to a URL.This can produce ambiguity
        /// during interpretation and require a REST mapping.In most cases, the dependency is on the group, resource tuple and the version of the actual struct is irrelevant.
        /// 5. We cannot easily change it.Because this type is embedded in many locations, updates to this type  will affect numerous schemas.Don't make new APIs embed an
        /// underspecified API type they do not control.Instead of using this type, create a locally provided and used type that is well-focused on your reference.
        /// For example, ServiceReferences for admission registration: https://github.com/kubernetes/api/blob/release-1.17/admissionregistration/v1/types.go#L533 .
        /// +k8s:deepcopy-gen:interfaces= k8s.io / apimachinery / pkg / runtime.Object+ structType = atomic
        /// </summary>
        public V1ObjectReference Related { get; set; }

        /// <summary>
        /// Name of the controller that emitted this Event, e.g. `kubernetes.io/kubelet`. +optional
        /// </summary>
        public string ReportingComponent { get; set; }

        /// <summary>
        /// ID of the controller instance, e.g. `kubelet-xyzf`. +optional
        /// </summary>
        public string ReportingInstance { get; set; }


        public V1EventSeries Series { get; set; }

        public V1EventSource Source { get; set; }

        /// <summary>
        ///  Type of this event (Normal, Warning), new types could be added in the future +optional
        /// </summary>
        public string Type { get; set; }
    }
}
