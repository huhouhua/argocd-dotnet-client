using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public class V1alpha1ApplicationSourcePlugin
    {
        /// <summary>
        /// EnvEntry represents an entry in the application's environment
        /// </summary>
        public Applicationv1alpha1EnvEntry[] Env { get; set; }


        public string Name { get; set; }


        public V1alpha1ApplicationSourcePluginParameter[] Parameters { get; set; }


    }

    public class Applicationv1alpha1EnvEntry
    {
        /// <summary>
        /// Name is the name of the variable, usually expressed in uppercase
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value is the value of the variable
        /// </summary>
        public string Value { get; set; }

    }

    public class V1alpha1ApplicationSourcePluginParameter
    {
        /// <summary>
        /// Array is the value of an array type parameter.
        /// </summary>
        public string[] Array { get; set; }

        /// <summary>
        /// Map is the value of a map type parameter.
        /// </summary>
        public string[] Map { get; set; }
        /// <summary>
        /// Name is the name identifying a parameter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// String_ is the value of a string type parameter
        /// </summary>
        public string String { get; set; }

    }
}
