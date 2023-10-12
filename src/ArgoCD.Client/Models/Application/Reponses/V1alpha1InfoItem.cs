using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public class V1alpha1InfoItem
    {
        /// <summary>
        /// Name is a human readable title for this piece of information.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value is human readable content.
        /// </summary>
        public string Value { get; set; }
    }
}
