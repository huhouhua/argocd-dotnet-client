using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.RepoCreds.Requests;

namespace ArgoCD.Client.Internal.Queries
{
    internal sealed class RepoCredsCreateBuilder : QueryBuilder<CreateRepoCredsOptions>
    {
        protected override void BuildCore(Query query, CreateRepoCredsOptions options)
        {
            query.Add("upsert", options.Upsert.ToLowerCaseString());
        }
    }
}
