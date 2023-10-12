using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Application.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ResourcesQueryBuilder : QueryBuilder<ResourcesQueryOptions>
    {
        protected override void BuildCore(Query query, ResourcesQueryOptions options)
        {
            if (options.Namespace.IsNotNullOrEmpty())
                query.Add("namespace", options.Namespace);

            if (options.Name.IsNotNullOrEmpty())
                query.Add("name", options.Name);

            if (options.Version.IsNotNullOrEmpty())
                query.Add("version", options.Version);

            if (options.Group.IsNotNullOrEmpty())
                query.Add("group", options.Group);

            if (options.Kind.IsNotNullOrEmpty())
                query.Add("kind", options.Kind);

            if (options.AppNamespace.IsNotNullOrEmpty())
                query.Add("appNamespace", options.AppNamespace);

            if (options.Project.IsNotNullOrEmpty())
                query.Add("project", options.Project);
        }
    }
}
