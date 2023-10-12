using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.RepoCreds.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class RepoCredsListQueryBuilder : QueryBuilder<RepoCredsQueryOptions>
    {
        protected override void BuildCore(Query query, RepoCredsQueryOptions options)
        {
            if (options.Url.IsNotNullOrEmpty())
            {
                query.Add("url", options.Url);
            }
        }

    }
}
