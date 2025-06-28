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

using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    /// <summary>
    /// NodeSystemInfo is a set of ids/uuids to uniquely identify the node.
    /// </summary>
    public class V1NodeSystemInfo
    {
        public string Architecture { get; set; }

        /// <summary>
        /// Boot ID reported by the node.
        /// </summary>
        public string BootID { get; set; }

        /// <summary>
        /// ContainerRuntime Version reported by the node through runtime remote API (e.g. containerd://1.4.2).
        /// </summary>
        public string ContainerRuntimeVersion { get; set; }

        /// <summary>
        /// Kernel Version reported by the node from &#39;uname -r&#39; (e.g. 3.16.0-0.bpo.4-amd64).
        /// </summary>
        public string KernelVersion { get; set; }

        /// <summary>
        /// KubeProxy Version reported by the node.
        /// </summary>
        public string KubeProxyVersion { get; set; }

        /// <summary>
        /// Kubelet Version reported by the node.
        /// </summary>
        public string KubeletVersion { get; set; }


        public string MachineID { get; set; }


        public string OperatingSystem { get; set; }

        /// <summary>
        /// OS Image reported by the node from /etc/os-release (e.g. Debian GNU/Linux 7 (wheezy)).
        /// </summary>
        public string OsImage { get; set; }

        public string SystemUUID { get; set; }

    }
}
