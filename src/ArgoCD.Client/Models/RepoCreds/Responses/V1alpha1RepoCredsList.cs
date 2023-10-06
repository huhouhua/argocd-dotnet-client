using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.RepoCreds.Responses
{
    public  class V1alpha1RepoCredsList
    {
        /// <summary>
        /// 	 RepositoryList is a collection of Repositories.
        /// </summary>
        public V1alpha1RepoCreds[] Items { get; set; }

        /// <summary>
        ///ListMeta describes metadata that synthetic resources must have, including lists and
        ///various status objects.A resource may have only one of {ObjectMeta, ListMeta}
        /// </summary>
        public V1ListMeta  MetaData { get; set; }

    }
}
