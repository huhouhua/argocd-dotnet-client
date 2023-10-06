using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public class V1alpha1ApplicationSourceJsonnet
    {
        public V1alpha1ApplicationSourceJsonnet()
        {
        }

        /// <summary>
        /// ExtVars is a list of Jsonnet External Variables
        /// </summary>
        public V1alpha1JsonnetVar[] ExtVars { get; set; }

        /// <summary>
        /// TLAS is a list of Jsonnet Top-level Arguments
        /// </summary>
        public string[] Libs { get; set; }

        /// <summary>
        /// JsonnetVar represents a variable to be passed to jsonnet during manifest generation
        /// </summary>
        public V1alpha1JsonnetVar[] Tlas { get; set; }

    }
}
