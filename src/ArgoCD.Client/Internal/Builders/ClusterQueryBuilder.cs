using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Cluster.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ClusterQueryBuilder : QueryBuilder<ClusterQueryOptions>
    {
        protected override void BuildCore(Query query, ClusterQueryOptions options)
        {
            if (options.Server.IsNotNullOrEmpty())
                query.Add("server",options.Server);

            if (options.Name.IsNotNullOrEmpty())
                query.Add("name", options.Name);

            if (options.IdType.IsNotNullOrEmpty())
                query.Add("id.type", options.IdType);

            if (options.IdValue.IsNotNullOrEmpty())
                query.Add("id.value", options.IdValue);
        }
    }
}
