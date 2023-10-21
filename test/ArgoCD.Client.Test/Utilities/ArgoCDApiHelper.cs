using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Http.Serialization;
namespace ArgoCD.Client.Test.Utilities
{
    internal static class ArgoCDApiHelper
    {
        public static IArgoCDHttpFacade GetFacadeWithUnauthorized()=>
            new DefaultArgoCDHttpFacade(() => {
                return new HttpClient()
                {
                    BaseAddress = new Uri(ArgoCDKubernetesFixture.ArgoCDHost),
                }; }, new RequestsJsonSerializer());
    }
}
