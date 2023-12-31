using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Repository.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class RepositoryQueryBuilder : QueryBuilder<RepositoryQueryOptions>
    {
        protected override void BuildCore(Query query, RepositoryQueryOptions options)
        {
            query.Add("forceRefresh", options.ForceRefresh);

            if (options.Repo.IsNotNullOrEmpty())
                query.Add("repo",options.Repo);

        }
    }
}
