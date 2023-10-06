using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Responses
{
    public class RepositoryHelmAppSpec
    {
        /// <summary>
        ///  helm file parameters
        /// </summary>
        public V1alpha1HelmFileParameter[]  FileParameters { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// the output of `helm inspect values`
        /// </summary>
        public V1alpha1HelmParameter[] Parameters { get; set; }


        public string[] ValueFiles { get; set; }

        /// <summary>
        /// the contents of values.yaml
        /// </summary>
        public string Values { get; set; }
    }
}
