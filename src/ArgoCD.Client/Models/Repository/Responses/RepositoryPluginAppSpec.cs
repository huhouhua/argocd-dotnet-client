using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ArgoCD.Client.Models.Repository.Responses
{
    public class RepositoryPluginAppSpec
    {
        public RepositoryPluginAppSpec() { }

        /// <summary>
        /// array is the default value of the parameter if the parameter is an array.
        /// </summary>
        public string[] Array { get; set; }

        /// <summary>
        /// collectionType is the type of value this parameter holds - either a single value (a string) or a collection
        /// (array or map). If collectionType is set, only the field with that type will be used.If collectionType is not
        /// set, string is the default. If collectionType is set to an invalid value, a validation error is thrown.
        /// </summary>
        public string CollectionType { get; set; }

        /// <summary>
        /// itemType determines the primitive data type represented by the parameter. Parameters are always encoded as
        /// strings, but this field lets them be interpreted as other primitive types.
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        ///  map is the default value of the parameter if the parameter is a map.
        /// </summary>
        public string[] Map { get; set; }

        /// <summary>
        /// name is the name identifying a parameter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// required defines if this given parameter is mandatory.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// string is the default value of the parameter if the parameter is a string.
        /// </summary>
        public string String { get; set; }

        /// <summary>
        /// title is a human-readable text of the parameter name.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// tooltip is a human-readable description of the parameter.
        /// </summary>
        public string Tooltip { get; set; }
    }
}
