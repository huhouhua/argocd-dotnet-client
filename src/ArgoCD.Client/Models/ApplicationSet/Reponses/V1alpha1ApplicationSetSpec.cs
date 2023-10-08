using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// V1alpha1ApplicationSetSpec represents a class of application set state.
    /// </summary>
    public class V1alpha1ApplicationSetSpec
    {
        /// <summary>
        /// ApplyNestedSelectors enables selectors defined within the generators of two level-nested matrix or merge generators
        /// </summary>
        public bool ApplyNestedSelectors { get; set; }

        /// <summary>
        /// 	ApplicationSetGenerator represents a generator at the top level of an ApplicationSet.
        /// </summary>
        public V1alpha1ApplicationSetGenerator[] Generators { get; set; }
    }
}
