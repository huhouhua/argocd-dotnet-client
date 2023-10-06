using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Cluster.Requests;

namespace ArgoCD.Client.Internal.Queries
{
    internal sealed class ClusterCreateBuilder : QueryBuilder<CreateClusterOptions>
    {
        protected override void BuildCore(Query query, CreateClusterOptions options)
        {
            query.Add("upsert", options.Upsert.ToLowerCaseString());
        }
    }
}
