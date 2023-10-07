using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class V1EventSeries
    {
        /// <summary>
        /// Number of occurrences in this series up to the last heartbeat time
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// MicroTime is version of Time with microsecond level precision.
        ///</summary>
        public V1MicroTime LastObservedTime { get; set; }
    }
}
