using System;
using System.Collections.Generic;
using System.Text;
using static ArgoCD.Client.Models.Repository.Requests.V1alpha1ApplicationSource;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public  class V1alpha1ApplicationSourceDirectory
    {
        public V1alpha1ApplicationSourceDirectory() { }


        /// <summary>
        /// Exclude contains a glob pattern to match paths against that should be explicitly excluded from being used during manifest generation
        /// </summary>
        public string Exclude { get; set; }

        /// <summary>
        /// Include contains a glob pattern to match paths against that should be explicitly included during manifest generation
        /// </summary>
        public string Include { get; set; }

        /// <summary>
        /// ApplicationSourceDirectory holds options for applications of type plain YAML or Jsonnet
        /// </summary>
        public V1alpha1ApplicationSourceJsonnet Jsonnet { get; set; }

        /// <summary>
        /// Recurse specifies whether to scan a directory recursively for manifests
        /// </summary>
        public bool Recurse { get; set; }

    }
}
