using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Application.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class TerminateOperationBuilder : QueryBuilder<TerminateOperationOptions>
    {
        protected override void BuildCore(Query query, TerminateOperationOptions options)
        {
            if (options.AppNamespace.IsNotNullOrEmpty())
                query.Add("appNamespace",options.AppNamespace);

            if (options.Project.IsNotNullOrEmpty())
                query.Add("project", options.Project);
        }
    }
}
