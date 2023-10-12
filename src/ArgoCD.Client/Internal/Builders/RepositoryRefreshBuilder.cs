using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.Repository.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class RepositoryRefreshBuilder : QueryBuilder<RepositoryRefreshOptions>
    {
        protected override void BuildCore(Query query, RepositoryRefreshOptions options)
        {
            query.Add("forceRefresh", options.ForceRefresh);
        }
    }
}
