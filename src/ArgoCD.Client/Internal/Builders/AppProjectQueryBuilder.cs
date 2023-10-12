using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Project.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal class AppProjectQueryBuilder : QueryBuilder<AppProjectQueryOptions>
    {
        protected override void BuildCore(Query query, AppProjectQueryOptions options)
        {
            if (options.Name.IsNotNullOrEmpty())
                query.Add("name",options.Name);

        }
    }
}
