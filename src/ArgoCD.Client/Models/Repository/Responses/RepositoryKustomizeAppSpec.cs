using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Responses
{
    public class RepositoryKustomizeAppSpec
    {
        /// <summary>
        /// images is a list of available images.
        /// </summary>
        public string[] Images { get; set; }

    }
}
