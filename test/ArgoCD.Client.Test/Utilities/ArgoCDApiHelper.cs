using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Http.Serialization;
namespace ArgoCD.Client.Test.Utilities
{
    internal static class ArgoCDApiHelper
    {
        private static HttpClientHandler Handler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (msg, cert, chain, errors) => true
        };
        public static IArgoCDHttpFacade GetFacadeWithUnauthorized()=>
            new DefaultArgoCDHttpFacade(() => {
                return new HttpClient(Handler)
                {
                    BaseAddress = new Uri(ArgoCDKubernetesFixture.ArgoCDHost),

                }; }, new RequestsJsonSerializer());


        public static IArgoCDHttpFacade GetFacade()=>
            new DefaultArgoCDHttpFacade(() => new(Handler)
            {
                BaseAddress = new Uri(ArgoCDKubernetesFixture.ArgoCDHost),
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", ArgoCDKubernetesFixture.Token),
                }
            }, new RequestsJsonSerializer());

        public static IArgoCDHttpFacade GetFacadeWithNotVersion()=>
            new DefaultArgoCDHttpFacade(() => new(Handler)
            {
                BaseAddress = new Uri(ArgoCDKubernetesFixture.ArgoCDHost.TrimEnd(new []{'/','v','1','/'})+"/"),
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", ArgoCDKubernetesFixture.Token),
                }
            }, new RequestsJsonSerializer());

    }
}
