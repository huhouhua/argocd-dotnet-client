using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Responses
{
    public class RepositoryRepoAppDetails
    {
        public RepositoryRepoAppDetails() { }

        /// <summary>
        /// DirectoryAppSpec contains directory
        /// </summary>
        public RepositoryDirectoryAppSpec Directory { get; set; }

        /// <summary>
        /// HelmAppSpec contains helm app name  in source repo
        /// </summary>
        public RepositoryHelmAppSpec Helm { get; set; }


        /// <summary>
        /// KustomizeAppSpec contains kustomize images
        /// </summary>
        public RepositoryKustomizeAppSpec Kustomize { get; set; }


        /// <summary>
        /// PluginAppSpec contains details about a plugin-type Application
        /// </summary>
        public RepositoryPluginAppSpec Plugin { get; set; }

        public string Type { get; set; }
    }




}
