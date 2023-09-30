using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Settings.Responses
{
    public sealed class V1alpha1KustomizeOptions
    {
        /// <summary>
        /// BinaryPath holds optional path to kustomize binary
        /// </summary>
        public string BinaryPath { get; set; }

        /// <summary>
        /// BuildOptions is a string of build parameters to use when calling `kustomize build`
        /// </summary>
        public string BuildOptions { get; set; }
    }
}
