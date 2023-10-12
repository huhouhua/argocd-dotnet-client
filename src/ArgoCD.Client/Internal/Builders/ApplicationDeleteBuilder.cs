using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Application.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ApplicationDeleteBuilder : QueryBuilder<DeleteApplicationOptions>
    {
        protected override void BuildCore(Query query, DeleteApplicationOptions options)
        {
            query.Add("cascade",options.Cascade.ToLowerCaseString());

            if (options.PropagationPolicy.IsNotNullOrEmpty())
                query.Add("propagationPolicy",options.PropagationPolicy);


            if (options.AppNamespace.IsNotNullOrEmpty())
                query.Add("appNamespace", options.AppNamespace);


            if (options.Project.IsNotNullOrEmpty())
                query.Add("project", options.Project);
        }
    }
}
