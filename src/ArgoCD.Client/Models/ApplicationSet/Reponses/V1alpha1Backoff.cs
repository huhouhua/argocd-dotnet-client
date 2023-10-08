using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    public class V1alpha1Backoff
    {
        /// <summary>
        /// Duration is the amount to back off. Default unit is seconds, but could also be a duration (e.g. "2m", "1h")
        /// </summary>
        public string Duration { get; set; }


        /// <summary>
        /// Factor is a factor to multiply the base duration after each failed retry
        /// </summary>
        public string Factor { get; set; }

        /// <summary>
        /// MaxDuration is the maximum amount of time allowed for the backoff strategy
        /// </summary>
        public string MaxDuration { get; set; }
    }
}
