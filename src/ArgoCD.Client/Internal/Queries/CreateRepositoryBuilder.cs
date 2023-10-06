using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Repository.Requests;

namespace ArgoCD.Client.Internal.Queries
{
    internal sealed class CreateRepositoryBuilder : QueryBuilder<CreateRepositoryOptions>
    {
        protected override void BuildCore(Query query, CreateRepositoryOptions options)
        {
            query.Add("upsert",options.Upsert.ToLowerCaseString());
            query.Add("credsOnly",options.CredsOnly.ToLowerCaseString());
        }
    }
}
