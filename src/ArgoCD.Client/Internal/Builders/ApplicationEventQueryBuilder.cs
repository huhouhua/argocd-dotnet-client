using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Application.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ApplicationEventQueryBuilder : QueryBuilder<ApplicationEventQueryOptions>
    {
        protected override void BuildCore(Query query, ApplicationEventQueryOptions options)
        {
            if (options.ResourceNamespace.IsNotNullOrEmpty())
                query.Add("resourceNamespace",options.ResourceNamespace);

            if (options.ResourceName.IsNotNullOrEmpty())
                query.Add("resourceName", options.ResourceName);

            if (options.ResourceUID.IsNotNullOrEmpty())
                query.Add("resourceUID", options.ResourceUID);

            if (options.AppNamespace.IsNotNullOrEmpty())
                query.Add("appNamespace", options.AppNamespace);

            if (options.Project.IsNotNullOrEmpty())
                query.Add("project", options.Project);
        }
    }
}
