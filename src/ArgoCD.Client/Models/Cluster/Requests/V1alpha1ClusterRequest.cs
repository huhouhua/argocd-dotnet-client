using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.Cluster.Responses;

namespace ArgoCD.Client.Models.Cluster.Requests
{
    public class V1alpha1ClusterRequest
    {
        /// <summary>
        /// Annotations for cluster secret metadata
        /// </summary>
        public Dictionary<string, string> Annotations { get; set; }
        /// <summary>
        /// Indicates if cluster level resources should be managed. This setting is used only if cluster is connected in a namespaced mode.
        /// </summary>
        public bool ClusterResources { get; set; }


        /// <summary>
        /// ClusterConfig is the configuration attributes.This structure is subset of the go-client
        /// rest.Config with annotations added for marshalling
        /// </summary>
        public V1alpha1ClusterConfig Config { get; set; }

        /// <summary>
        /// ConnectionState contains information about remote resource connection state, currently used for clusters and repositories
        /// </summary>
        public V1alpha1ConnectionState ConnectionState { get; set; }

        /// <summary>
        /// ClusterInfo contains information about the cluster
        /// </summary>
        public V1alpha1ClusterInfo Info { get; set; }

        /// <summary>
        /// Labels for cluster secret metadata
        /// </summary>
        public Dictionary<string, string> Labels { get; set; }

        /// <summary>
        /// Name of the cluster. If omitted, will use the server address
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Holds list of namespaces which are accessible in that cluster. Cluster level resources will be ignored if namespace list is not empty.
        /// </summary>
        public string[] Namespaces { get; set; }

        /// <summary>
        /// Reference between project and cluster that allow you automatically to be added as item inside Destinations project entity
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.  +protobuf.options.marshal&#x3D;false +protobuf.as&#x3D;Timestamp +protobuf.options.(gogoproto.goproto_stringer)&#x3D;false
        /// </summary>
        public DateTimeOffset RefreshRequestedAt { get; set; }

        /// <summary>
        ///  Server is the API server URL of the Kubernetes cluster
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// DEPRECATED: use Info.ServerVersion field instead. The server version
        /// </summary>
        public string ServerVersion { get; set; }

        /// <summary>
        /// Shard contains optional shard number. Calculated on the fly by the application controller if not specified.
        /// </summary>
        public long Shard { get; set; }
    }
}
