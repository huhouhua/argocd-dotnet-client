using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Cluster.Responses
{
    public class V1alpha1ExecProviderConfig
    {
        /// <summary>
        /// Preferred input version of the ExecInfo
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Arguments to pass to the command when executing it
        /// </summary>
        public string[] Args { get; set; }
        /// <summary>
        /// Command to execute
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// Env defines additional environment variables to expose to the process
        /// </summary>
        public string[] Env { get; set; }

        /// <summary>
        ///  This text is shown to the user when the executable doesn't seem to be present
        /// </summary>
        public string InstallHint { get; set; }
    }
}
