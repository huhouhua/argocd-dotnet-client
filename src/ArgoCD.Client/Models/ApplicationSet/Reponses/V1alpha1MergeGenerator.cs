using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.ApplicationSet.Reponses
{
    /// <summary>
    /// MergeGenerator merges the output of two or more generators. Where the values for all specified merge keys are equal between two sets of generated parameters, the parameter sets will be merged with the parameters from the latter generator taking precedence. Parameter sets with merge keys not present in the base generator&#39;s params will be ignored. For example, if the first generator produced [{a: &#39;1&#39;, b: &#39;2&#39;}, {c: &#39;1&#39;, d: &#39;1&#39;}] and the second generator produced [{&#39;a&#39;: &#39;override&#39;}], the united parameters for merge keys &#x3D; [&#39;a&#39;] would be [{a: &#39;override&#39;, b: &#39;1&#39;}, {c: &#39;1&#39;, d: &#39;1&#39;}].  MergeGenerator supports template overriding. If a MergeGenerator is one of multiple top-level generators, its template will be merged with the top-level generator before the parameters are applied.
    /// </summary>
    public class V1alpha1MergeGenerator
    {


        public V1alpha1ApplicationSetNestedGenerator[] Generators { get; set; }


        public string[] MergeKeys { get; set; }

        public V1alpha1ApplicationSetTemplate Template { get; set; }
    }
}
