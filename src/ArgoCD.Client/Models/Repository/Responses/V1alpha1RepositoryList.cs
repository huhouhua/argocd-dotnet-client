using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Responses
{
    /// <summary>
    /// RepositoryList is a collection of Repositories.
    /// </summary>
    public class V1alpha1RepositoryList
    {
        public V1alpha1RepositoryList() { }

        /// <summary>
        /// Repository is a repository holding application configurations
        /// </summary>
        public V1alpha1Repository[] Items { get; set; }

        /// <summary>
        ///ListMeta describes metadata that synthetic resources must have, including lists and
        ///various status objects.A resource may have only one of {ObjectMeta, ListMeta}
        /// </summary>
        public V1ListMeta MetaData { get; set; }
    }
}
