using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Application.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ApplicationWatchQueryBuilder : QueryBuilder<ApplicationWatchQueryOptions>
    {
        protected override void BuildCore(Query query, ApplicationWatchQueryOptions options)
        {
            if (options.Name.IsNotNullOrEmpty())
                query.Add("name",options.Name);

            if (options.Refresh.IsNotNullOrEmpty())
                query.Add("refresh", options.Refresh);

                query.Add("projects", options.Projects);
                query.Add("project", options.Project);

            if (options.ResourceVersion.IsNotNullOrEmpty())
                query.Add("resourceVersion", options.ResourceVersion);

            if (options.Selector.IsNotNullOrEmpty())
                query.Add("selector", options.Selector);

            if (options.Repo.IsNotNullOrEmpty())
                query.Add("repo", options.Repo);

            if (options.AppNamespace.IsNotNullOrEmpty())
                query.Add("appNamespace", options.AppNamespace);
        }
    }
}
