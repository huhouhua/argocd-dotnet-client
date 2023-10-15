using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace ArgoCD.Client.Models.Application.Reponses
{
    public  class V1alpha1ChartDetails
    {
        public string Description { get; set; }

        public string Home { get; set; }


        /// <summary>
        /// List of maintainer details, name and email, e.g. ["John Doe <john_doe@my-company.com>"]
        /// </summary>
        public string[] Maintainers { get; set; }
    }
}
