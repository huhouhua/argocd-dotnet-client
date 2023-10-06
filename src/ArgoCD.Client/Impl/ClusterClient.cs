using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Impl
{
    public class ClusterClient: IClusterClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;

        internal ClusterClient(IArgoCDHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

    }
}
