using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.ApplicationSet.Requests;

namespace ArgoCD.Client.Internal.Queries
{
    internal class ApplicationSetQueryBuilder : QueryBuilder<ApplicationSetQueryOptions>
    {
        public ApplicationSetQueryBuilder() { }

        protected override void BuildCore(Query query, ApplicationSetQueryOptions options)
        {
            if (options.AppsetNamespace.IsNotNullOrEmpty())
                query.Add("appsetNamespace", options.AppsetNamespace);
        }
    }
}
