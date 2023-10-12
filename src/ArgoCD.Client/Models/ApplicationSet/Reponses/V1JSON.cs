using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// JSON represents any valid JSON value.
    /// These types are supported: bool, int64, float64, string, [] interface{ }, map[string] interface{ }
    /// and nil.
    /// </summary>
    public class V1JSON
    {
        public V1JSON() { }

        public byte[] Raw { get; set; }
    }
}
