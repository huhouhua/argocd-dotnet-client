using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Application.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ApplicationLinksQueryBuilder : QueryBuilder<ApplicationLinksQueryOptions>
    {
        protected override void BuildCore(Query query, ApplicationLinksQueryOptions options)
        {
            if (options.Namespace.IsNotNullOrEmpty())
                query.Add("namespace",options.Namespace);

            if (options.Project.IsNotNullOrEmpty())
                query.Add("project", options.Project);
            
        }
    }
}
