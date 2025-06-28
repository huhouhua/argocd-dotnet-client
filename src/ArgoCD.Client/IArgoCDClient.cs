// Copyright 2024 The argocd-dotnet-client Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ArgoCD.Client.Models.Session.Responses;

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
        IGPGKeyClient IGPGKey { get; }


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
        ///  Access ArgoCD's ApplicationSet API.
        /// </summary>
        IApplicationSetClient ApplicationSet { get; }

        /// <summary>
        ///  Access ArgoCD's Project API.
        /// </summary>
         IProjectClient Project { get;  }

        string HostUrl { get; }

        /// <summary>
        /// Authenticates with ArgoCD API using user credentials.
        /// </summary>
        Task<Session> LoginAsync(string username, string password);
    }
}
