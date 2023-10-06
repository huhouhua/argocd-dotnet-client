using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Responses
{
    public class V1alpha1HelmFileParameter
    {
        /// <summary>
        /// Name is the name of the Helm parameter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Path is the path to the file containing the values for the Helm parameter
        /// </summary>
        public string Path { get; set; }
    }
}
