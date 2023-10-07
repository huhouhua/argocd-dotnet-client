using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1EventList
    {
        public V1EventList() { }

        /// <summary>
        /// List of events
        /// </summary>
        public V1Event[] Items { get; set; }



        /// <summary>
        ///ListMeta describes metadata that synthetic resources must have, including lists and
        ///various status objects.A resource may have only one of {ObjectMeta, ListMeta}
        /// </summary>
        public V1ListMeta MetaData { get; set; }
    }
}
