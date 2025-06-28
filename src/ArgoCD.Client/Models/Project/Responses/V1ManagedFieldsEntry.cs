// Copyright 2024 The argocd-dotnet-client Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Reflection.Emit;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

namespace ArgoCD.Client.Models.Project.Responses
{
    /// <summary>
    /// ManagedFieldsEntry is a workflow-id, a FieldSet and the group version of the resource that the fieldset applies to.
    /// </summary>
    public class V1ManagedFieldsEntry
    {
        public V1ManagedFieldsEntry() { }


        /// <summary>
        /// APIVersion defines the version of this resource that this field set
        /// applies to.The format is "group/version" just like the top-level
        /// APIVersion field.It is necessary to track the version of a field
        /// set because it cannot be automatically converted.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// FieldsType is the discriminator for the different fields format and version. There is currently only one possible value: "FieldsV1"
        /// </summary>
        public string FieldsType { get; set; }


        /// <summary>
        /// FieldsV1 stores a set of fields in a data structure like a Trie, in JSON format.
        /// Each key is either a '.' representing the field itself, and will always map to an empty set,
        /// or a string representing a sub-field or item.The string will follow one of these four formats:
        /// 'f:', where is the name of a field in a struct, or key in a map
        /// 'v:', where is the exact json formatted value of a list item
        /// 'i:', where is position of a item in a list
        /// 'k:', where is a map of a list item's key fields to their unique values
        /// If a key maps to an empty Fields value, the field that key represents is part of the set.
        /// The exact format is defined in sigs.k8s.io/structured-merge-diff +protobuf.options.(gogoproto.goproto_stringer)= false
        /// </summary>
        public V1FieldsV1 FieldsV1 { get; set; }

        /// <summary>
        /// Manager is an identifier of the workflow managing these fields.
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// Operation is the type of operation which lead to this ManagedFieldsEntry being created.
        /// The only valid values for this field are 'Apply' and 'Update'.
        /// </summary>
        public string Operation { get; set; }


        /// <summary>
        /// Subresource is the name of the subresource used to update that object, or
        /// empty string if the object was updated through the main resource.The
        /// value of this field is used to distinguish between managers, even if they
        /// share the same name.For example, a status update will be distinct from a
        /// regular update using the same manager name.
        /// Note that the APIVersion field is not related to the Subresource field and
        /// it always corresponds to the version of the main resource.
        /// </summary>
        public string Subresource { get; set; }

        /// <summary>
        /// Time is a wrapper around time.Time which supports correct marshaling to YAML and JSON.  Wrappers are provided for many of the factory methods that the time package offers.  +protobuf.options.marshal&#x3D;false +protobuf.as&#x3D;Timestamp +protobuf.options.(gogoproto.goproto_stringer)&#x3D;false
        /// </summary>
        public DateTimeOffset Time { get; set; }
    }
}
