using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1ApplicationSetStatus
    {
        public V1alpha1ApplicationSetStatus() { }

        /// <summary>
        /// Application contains the name of the Application resource
        /// </summary>
        public string Application { get; set; }


        public V1Time LastTransitionTime { get; set; }

        /// <summary>
        /// Message contains human-readable message indicating details about the status
        /// </summary>

        public string Message { get; set; }

        /// <summary>
        /// Status contains the AppSet's perceived status of the managed Application resource: (Waiting, Pending, Progressing, Healthy)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Step tracks which step this Application should be updated in
        /// </summary>
        public string Step { get; set; }
    }
}
