using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Responses
{
    public class V1alpha1HelmParameter
    {
        /// <summary>
        /// ForceString determines whether to tell Helm to interpret booleans and numbers as strings
        /// </summary>
        public bool ForceString { get; set; }

        /// <summary>
        /// Name is the name of the Helm parameter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value is the value for the Helm parameter
        /// </summary>
        public string Value { get; set; }
    }
}
