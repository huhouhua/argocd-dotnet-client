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
using System.Text;
using ArgoCD.Client.Models.Repository.Requests;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSource
    {
        public V1alpha1ApplicationSource() { }

        /// <summary>
        /// Chart is a Helm chart name, and must be specified for applications sourced from a Helm repo.
        /// </summary>
        public string Chart { get; set; }

        /// <summary>
        /// ApplicationSourceDirectory holds options for applications of type plain YAML or Jsonnet
        /// </summary>
        public V1alpha1ApplicationSourceDirectory Directory { get; set; }

        /// <summary>
        /// ApplicationSourceHelm holds helm specific options
        /// </summary>
        public V1alpha1ApplicationSourceHelm Helm { get; set; }

        /// <summary>
        /// ApplicationSourceKustomize holds options specific to an Application source specific to Kustomize
        /// </summary>
        public V1alpha1ApplicationSourceKustomize Kustomize { get; set; }

        /// <summary>
        /// Path is a directory path within the Git repository, and is only valid for applications sourced from Git.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// ApplicationSourcePlugin holds options specific to config management plugins
        /// </summary>
        public V1alpha1ApplicationSourcePlugin Plugin { get; set; }

        /// <summary>
        /// Ref is reference to another source within sources field. This field will not be used if used with a source tag.
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// RepoURL is the URL to the repository (Git or Helm) that contains the application manifests
        /// </summary>
        public string RepoURL { get; set; }

        /// <summary>
        /// TargetRevision defines the revision of the source to sync the application to.
        /// In case of Git, this can be commit, tag, or branch.If omitted, will equal to HEAD.
        /// In case of Helm, this is a semver tag for the Chart's version.
        /// </summary>
        public string TargetRevision { get; set; }
    }
}
