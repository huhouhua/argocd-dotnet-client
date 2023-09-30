using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Settings.Responses
{
    public sealed class ClusterOIDCConfig
    {
        public string CliClientID { get; set; }
        public string ClientID { get; set; }
        public OidcClaim IdTokenClaims { get; set; }
        public string Issuer { get; set; }
        public string Name { get; set; }
        public string[] Scopes { get; set; }
    }

    public sealed class OidcClaim
    {
        public bool Essential { get; set; }
        public string Value { get; set; }
        public string[] Values { get; set; }
    }
}
