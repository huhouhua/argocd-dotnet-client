using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.GPKKey.Requests;

namespace ArgoCD.Client.Internal.Queries
{
    internal class GPKKeyCreateQueryBuilder : QueryBuilder<CreateGPKKeyOptions>
    {
        protected override void BuildCore(Query query, CreateGPKKeyOptions options)
        {
            query.Add("upsert", options.Upsert.ToLowerCaseString());
        }
    }
}
