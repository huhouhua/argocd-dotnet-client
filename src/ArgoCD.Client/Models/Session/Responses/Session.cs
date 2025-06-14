using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArgoCD.Client.Models.Session.Responses
{
    /// <summary>
    ///Session wraps the created token or returns an empty string if deleted
    /// </summary>
    public class Session
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
