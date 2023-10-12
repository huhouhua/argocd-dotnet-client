using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Cluster.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ClusterUpdateBuilder : QueryBuilder<UpdateClusterOptions>
    {
        protected override void BuildCore(Query query, UpdateClusterOptions options)
        {
            if (options.IdValue.IsNotNullOrEmpty())
            {
                query.Add("id.value",options.IdValue);
            }

            foreach (string item in options.UpdatedFields)
            {
                query.Add("updatedFields", item);
            }
        }
    }
}
