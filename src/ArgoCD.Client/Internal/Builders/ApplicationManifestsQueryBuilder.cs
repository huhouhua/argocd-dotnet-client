using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Application.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ApplicationManifestsQueryBuilder:QueryBuilder<ApplicationManifestsQueryOptions>
    {
        public ApplicationManifestsQueryBuilder() { }

        protected override void BuildCore(Query query, ApplicationManifestsQueryOptions options)
        {
            if (options.Revision.IsNotNullOrEmpty())
                query.Add("revision", options.Revision);

            if (options.AppNamespace.IsNotNullOrEmpty())
                query.Add("appNamespace",options.AppNamespace);

            if (options.Project.IsNotNullOrEmpty())
                query.Add("project", options.Project);
        }
    }
}
