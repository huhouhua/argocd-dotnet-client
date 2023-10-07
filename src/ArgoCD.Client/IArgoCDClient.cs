using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client
{
    public interface IArgoCDClient
    {
        /// <summary>
        ///  Access ArgoCD's Version API.
        /// </summary>
        IVersionClient Version { get; }


        /// <summary>
        ///  Access ArgoCD's Settings API.
        /// </summary>
        ISettingsClient Settings { get; }

        /// <summary>
        ///  Access ArgoCD's Notification API.
        /// </summary>
        INotificationClient Notification { get; }


        /// <summary>
        ///  Access ArgoCD's Account API.
        /// </summary>
        IAccountClient Account { get; }


        /// <summary>
        ///  Access ArgoCD's Session API.
        /// </summary>
         ISessionClient Session { get; }


        /// <summary>
        ///  Access ArgoCD's Cluster API.
        /// </summary>
        IClusterClient Cluster { get; }


        /// <summary>
        ///  Access ArgoCD's Certificate API.
        /// </summary>
        ICertificateClient Certificate { get; }


        /// <summary>
        ///  Access ArgoCD's GPKKey API.
        /// </summary>
        IGPKKeyClient GPKKey { get; }


        /// <summary>
        ///  Access ArgoCD's RepoCreds API.
        /// </summary>
        IRepoCredsClient RepoCreds { get; }

        /// <summary>
        ///  Access ArgoCD's Repository API.
        /// </summary>
         IRepositoryClient Repository { get;  }

        /// <summary>
        ///  Access ArgoCD's Application API.
        /// </summary>
         IApplicationClient Application { get;  }


        /// <summary>
        ///  Access ArgoCD's Project API.
        /// </summary>
         IProjectClient Project { get;  }


        string HostUrl { get; }
    }
}
