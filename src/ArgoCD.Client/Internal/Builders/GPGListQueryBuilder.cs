using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.GPKKey.Requests;


namespace ArgoCD.Client.Internal.Builders
{
    internal class GPGListQueryBuilder : QueryBuilder<GPGListQueryOptions>
    {
        protected override void BuildCore(Query query, GPGListQueryOptions options)
        {
            if (options.KeyID.IsNotNullOrEmpty())
            {
                query.Add("keyID", options.KeyID);
            }
        }
    }
}
