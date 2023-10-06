using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ArgoCD.Client.Models.Cluster.Responses
{
    public  class V1Time
    {
        /// <summary>
        /// Non-negative fractions of a second at nanosecond resolution. Negative
        /// second values with fractions must still have non-negative nanos values
        /// that count forward in time.Must be from 0 to 999,999,999
        /// inclusive.This field may be limited in precision depending on context.
        /// </summary>
        public int Nanos { get; set; }

        /// <summary>
        /// Represents seconds of UTC time since Unix epoch 1970-01-01T00:00:00Z.Must be from 0001-01-01T00:00:00Z to 9999-12-31T23:59:59Z inclusive.
        /// </summary>
        public string Seconds { get; set; }

    }
}
