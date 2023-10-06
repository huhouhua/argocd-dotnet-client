using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Repository.Requests;

namespace ArgoCD.Client.Internal.Queries
{
    internal sealed class RepositoryQueryAppBuilder : QueryBuilder<RepositoryQueryAppOptions>
    {
        protected override void BuildCore(Query query, RepositoryQueryAppOptions options)
        {
            if (options.Revision.IsNotNullOrEmpty())
                query.Add("revision", options.Revision);

            if (options.AppName.IsNotNullOrEmpty())
                query.Add("appName", options.AppName);

            if (options.AppProject.IsNotNullOrEmpty())
                query.Add("appProject", options.AppProject);

        }
    }
}
