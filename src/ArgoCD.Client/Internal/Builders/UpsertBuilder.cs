using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models;

namespace ArgoCD.Client.Internal.Builders
{
    internal class UpsertBuilder : QueryBuilder<UpsertOptions>
    {
        protected override void BuildCore(Query query, UpsertOptions options)
        {
            query.Add("upsert", options.Upsert.ToLowerCaseString());
        }
    }
}
