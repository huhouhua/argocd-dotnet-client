using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Http.Serialization;
using ArgoCD.Client.Internal.Builders;
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

            var upsertBuilder = new UpsertBuilder();
            var certificateQueryBuilder = new CertificateQueryBuilder();
            var gPKKeyDeleteBuilder = new GPKKeyDeleteBuilder();
            var repoCredsListQueryBuilder = new RepoCredsListQueryBuilder();
            var clusterQueryBuilder = new ClusterQueryBuilder();
            var clusterUpdateBuilder = new ClusterUpdateBuilder();
            var repositoryQueryBuilder = new RepositoryQueryBuilder();
            var createRepositoryBuilder = new CreateRepositoryBuilder();
            var repositoryRefreshBuilder = new RepositoryRefreshBuilder();
            var repositoryQueryAppBuilder = new RepositoryQueryAppBuilder();
            var validateAccessBuilder = new ValidateAccessBuilder();
            var appProjectQueryBuilder = new AppProjectQueryBuilder();
            var projectTokenDeleteBuilder = new ProjectTokenDeleteBuilder();
            var applicationSetQueryBuilder = new ApplicationSetQueryBuilder();
            var applicationSetListQueryBuilder = new ApplicationSetListQueryBuilder();

            var applicationListQueryBuilder = new ApplicationListQueryBuilder();
            var applicationQueryBuilder = new ApplicationQueryBuilder();
            var applicationCreateOrUpdateBuilder = new ApplicationCreateOrUpdateBuilder();
            var applicationDeleteBuilder = new ApplicationDeleteBuilder();
            var resourcesQueryBuilder = new ResourcesQueryBuilder();
            var applicationEventQueryBuilder = new ApplicationEventQueryBuilder();
            var applicationLinksQueryBuilder = new ApplicationLinksQueryBuilder();
            var applicationLogQueryBuilder = new ApplicationLogQueryBuilder();
            var applicationManifestsQueryBuilder = new ApplicationManifestsQueryBuilder();
            var terminateOperationBuilder = new TerminateOperationBuilder();
            var applicationResourceQueryBuilder = new ApplicationResourceQueryBuilder();
            var applicationResourceCreateBuilder = new ApplicationResourceCreateBuilder();
            var applicationResourceDeleteBuilder = new ApplicationResourceDeleteBuilder();
            var applicationDetailsQueryBuilder = new ApplicationDetailsQueryBuilder();
            var applicationUpdateSpecBuilder = new ApplicationUpdateSpecBuilder();
            var applicationWatchQueryBuilder = new ApplicationWatchQueryBuilder();

            Version = new VersionClient(_httpFacadeFromApp);
            Settings = new SettingsClient(_httpFacade);
            Notification = new NotificationClient(_httpFacade);
            Session = new SessionClient(_httpFacade);
            Account = new AccountClient(_httpFacade);
            Certificate = new CertificateClient(_httpFacade, upsertBuilder, certificateQueryBuilder);
            GPKKey = new GPKKeyClient(_httpFacade, upsertBuilder, gPKKeyDeleteBuilder);
            RepoCreds = new RepoCredsClient(_httpFacade, repoCredsListQueryBuilder, upsertBuilder);
            Cluster = new ClusterClient(_httpFacade,clusterQueryBuilder,clusterUpdateBuilder, upsertBuilder);
            Repository = new RepositoryClient(_httpFacade,repositoryQueryBuilder,createRepositoryBuilder, repositoryRefreshBuilder, repositoryQueryAppBuilder, validateAccessBuilder);
            Project = new ProjectClient(_httpFacade,appProjectQueryBuilder,projectTokenDeleteBuilder);
            ApplicationSet = new ApplicationSetClient(_httpFacade,upsertBuilder,applicationSetQueryBuilder,applicationSetListQueryBuilder);
            Application = new ApplicationClient(_httpFacade, applicationListQueryBuilder,
                applicationQueryBuilder,applicationCreateOrUpdateBuilder,
                applicationDeleteBuilder, resourcesQueryBuilder,
                applicationEventQueryBuilder,applicationLinksQueryBuilder,
                applicationLogQueryBuilder,applicationManifestsQueryBuilder,
                terminateOperationBuilder,applicationResourceQueryBuilder,
                applicationResourceCreateBuilder,applicationResourceDeleteBuilder,
                applicationDetailsQueryBuilder,applicationUpdateSpecBuilder,
                applicationWatchQueryBuilder);
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
        ///  Access ArgoCD's Notification API.
        /// </summary>
        public  INotificationClient Notification { get; private set; }

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
        ///  Access ArgoCD's ApplicationSet API.
        /// </summary>
        public IApplicationSetClient ApplicationSet { get; private set; }


        /// <summary>
        ///  Access ArgoCD's Project API.
        /// </summary>
        public IProjectClient Project { get; private set; }

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
