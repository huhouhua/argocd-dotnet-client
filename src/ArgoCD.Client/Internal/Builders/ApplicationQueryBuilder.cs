using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Application.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ApplicationQueryBuilder : QueryBuilder<ApplicationQueryOptions>
    {

        protected override void BuildCore(Query query, ApplicationQueryOptions options)
        {

            if (options.Refresh.IsNotNullOrEmpty())
                query.Add("refresh", options.Refresh);

            if (options.ResourceVersion.IsNotNullOrEmpty())
                query.Add("resourceVersion", options.ResourceVersion);

            if (options.Selector.IsNotNullOrEmpty())
                query.Add("selector", options.Selector);

            if (options.Repo.IsNotNullOrEmpty())
                query.Add("repo", options.Repo);

            if (options.AppNamespace.IsNotNullOrEmpty())
                query.Add("appNamespace", options.AppNamespace);

            query.Add("projects", options.Projects);
            query.Add("project", options.Project);
        }
    }
}
