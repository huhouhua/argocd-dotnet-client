using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.Repository.Responses;
using Microsoft.VisualBasic;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public class V1alpha1ApplicationSourceHelm
    {
        /// <summary>
        /// FileParameters are file parameters to the helm template
        /// </summary>
        public V1alpha1HelmFileParameter[] FileParameters { get; set; }

        /// <summary>
        /// IgnoreMissingValueFiles prevents helm template from failing when valueFiles do not exist locally by not appending them to helm template --values
        /// </summary>
        public bool IgnoreMissingValueFiles { get; set; }

        /// <summary>
        /// Parameters is a list of Helm parameters which are passed to the helm template command upon manifest generation
        /// </summary>
        public V1alpha1HelmParameter[] Parameters { get; set; }

        /// <summary>
        ///  PassCredentials pass credentials to all domains (Helm's --pass-credentials)
        /// </summary>
        public bool PassCredentials { get; set; }

        /// <summary>
        /// ReleaseName is the Helm release name to use. If omitted it will use the application name
        /// </summary>
        public string ReleaseName { get; set; }


        /// <summary>
        /// SkipCrds skips custom resource definition installation step (Helm's --skip-crds)
        /// </summary>
        public bool SkipCrds { get; set; }

        /// <summary>
        /// ValuesFiles is a list of Helm value files to use when generating a template
        /// </summary>
        public string[] ValueFiles { get; set; }

        /// <summary>
        /// Values specifies Helm values to be passed to helm template, typically defined as a block. ValuesObject takes precedence over Values, so use one or the other. +patchStrategy=replace
        /// </summary>
        public string Values { get; set; }

        /// <summary>

        /// RawExtension is used to hold extensions in external versions.

        ///  To use this, make a field which has RawExtension as its type in your external, versioned
        ///  struct, and Object in your internal struct. You also need to register your
        ///    various plugin types.

        // Internal package:
        ///  type MyAPIObject struct {
        ///      runtime.TypeMeta json:",inline"
        ///  MyPlugin runtime.Object json:"myPlugin"
        /// }
        ///  type PluginA struct {
        ///   AOption string json:"aOption"
        ///}

        // External package:
        ///  type MyAPIObject struct {
        /// runtime.TypeMeta json:",inline"
        ///  MyPlugin runtime.RawExtension json:"myPlugin"
        ///   }
        ///   type PluginA struct {
        ///     AOption string json:"aOption"
        /// }

        /// //On the wire, the JSON will look something like this:
        ///{
        /// "kind":"MyAPIObject",
        ///"apiVersion":"v1",
        ///"myPlugin": {
        ///      "kind":"PluginA",
        ///"aOption":"foo",
        ///},
        /// }

        ///So what happens? Decode first uses json or yaml to unmarshal the serialized data into
        ///your external MyAPIObject. That causes the raw JSON to be stored, but not unpacked.
        ///The next step is to copy (using pkg/ conversion) into the internal struct. The runtime
        /// package's DefaultScheme has conversion functions installed which will unpack the
        ///  JSON stored in RawExtension, turning it into the correct object type, and storing it
        ///in the Object. (TODO: In the case where the object is of an unknown type, a
        /// runtime.Unknown object will be created and stored.)

        ///+k8s:deepcopy - gen = true
        ///+ protobuf = true
        ///+ k8s:openapi - gen = true
        /// </summary>
        public RuntimeRawExtension ValuesObject { get; set; }

        /// <summary>
        /// Version is the Helm version to use for templating ("3")
        /// </summary>
        public string Version { get; set; }
    }
}
