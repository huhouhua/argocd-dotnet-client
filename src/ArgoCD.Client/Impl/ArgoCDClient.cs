using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Http.Serialization;
using ArgoCD.Client.Internal.Queries;
using ArgoCD.Client.Internal.Utilities;

namespace ArgoCD.Client.Impl
{
    /// <summary>
    /// A client for the ArgoCD API v1
    /// </summary>
    public sealed class ArgoCDClient: IArgoCDClient
    {
        private  IArgoCDHttpFacade _httpFacade;
        private IArgoCDHttpFacade _httpFacadeFromApp;

        public ArgoCDClient(Func<HttpClient> clientFunc)
        {
            Guard.NotNull(clientFunc, nameof(clientFunc));
            Setup(clientFunc);
        }

        public ArgoCDClient(IHttpClientFactory clientFactory)
        {
            Guard.NotNull(clientFactory, nameof(clientFactory));
            Setup(() => clientFactory.CreateClient());
          
        }

        public ArgoCDClient(IHttpClientFactory clientFactory, string clientName)
        {
            Guard.NotNull(clientFactory, nameof(clientFactory));
            Guard.NotNullOrDefault(clientName, nameof(clientName));
            Setup(() => clientFactory.CreateClient(clientName));
        }

        public ArgoCDClient(HttpClient client)
        {
            Guard.NotNull(client, nameof(client));
            Setup(() => client);
        }

        public ArgoCDClient(string hostUrl, string authenticationToken = "", HttpMessageHandler httpMessageHandler = null, TimeSpan? clientTimeout = null)
        {
            Guard.NotEmpty(hostUrl, nameof(hostUrl));
            Guard.NotNull(authenticationToken, nameof(authenticationToken));
            HostUrl = FixBaseUrl(hostUrl);
            Setup(() =>
            {
                var client = new HttpClient(httpMessageHandler ?? new HttpClientHandler()) { BaseAddress = new Uri(hostUrl) };
                if (clientTimeout.HasValue)
                {
                    client.Timeout = clientTimeout.Value;
                }
                return client;
            });
        }

        private void Setup(Func<HttpClient> clientFunc)
        {
            var jsonSerializer = new RequestsJsonSerializer();
            _httpFacade = new DefaultArgoCDHttpFacade(
                 clientFunc,
                 jsonSerializer);

            _httpFacadeFromApp = new DefaultArgoCDHttpFacade(
              () =>
              {
                  var client = clientFunc();
                  client.BaseAddress = new Uri("/api");
                  return client;
              },
              jsonSerializer);

            var certificateCreateQueryBuilder = new CertificateCreateQueryBuilder();
            var certificateQueryBuilder = new CertificateQueryBuilder();
            var gPKKeyCreateQueryBuilder = new GPKKeyCreateQueryBuilder();
            var gPKKeyDeleteQueryBuilder = new GPKKeyDeleteQueryBuilder();


            Version = new VersionClient(_httpFacadeFromApp);
            Settings = new SettingsClient(_httpFacade);
            Session = new SessionClient(_httpFacade);
            Account = new AccountClient(_httpFacade);
            Certificate = new CertificateClient(_httpFacade,certificateCreateQueryBuilder,certificateQueryBuilder);
            GPKKey = new GPKKeyClient(_httpFacade, gPKKeyCreateQueryBuilder, gPKKeyDeleteQueryBuilder);

        }


        /// <summary>
        ///  Access ArgoCD's Version API.
        /// </summary>
        public IVersionClient Version { get; private set; }


        /// <summary>
        ///  Access ArgoCD's Settings API.
        /// </summary>
        public ISettingsClient Settings { get; private set; }


        /// <summary>
        ///  Access ArgoCD's Account API.
        /// </summary>
        public IAccountClient Account { get; private set; }


        /// <summary>
        ///  Access ArgoCD's Session API.
        /// </summary>
        public ISessionClient Session { get;private set;}


        /// <summary>
        ///  Access ArgoCD's Cluster API.
        /// </summary>
        public IClusterClient Cluster { get; private set; }


        /// <summary>
        ///  Access ArgoCD's Certificate API.
        /// </summary>
        public ICertificateClient Certificate { get; private set; }


        /// <summary>
        ///  Access ArgoCD's GPKKey API.
        /// </summary>
        public IGPKKeyClient GPKKey { get; private set; }


        /// <summary>
        ///  Access ArgoCD's RepoCreds API.
        /// </summary>
        public IRepoCredsClient RepoCreds { get; private set; }

        /// <summary>
        ///  Access ArgoCD's Repository API.
        /// </summary>
        public IRepositoryClient Repository { get; private set; }

        /// <summary>
        ///  Access ArgoCD's Application API.
        /// </summary>
        public IApplicationClient Application { get; private set; }


        /// <summary>
        ///  Access ArgoCD's Project API.
        /// </summary>
        public IProjectClient ProjectClient { get; private set; }

        public string HostUrl { get; }

        private static string FixBaseUrl(string url)
        {
            url = url.TrimEnd('/');
            string prefix = "/api/v1";
            if (!url.EndsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                url = string.Concat(url, prefix);
            }
            return $"{url}/";
        }
    }
}
