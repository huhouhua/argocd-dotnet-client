using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.ApplicationSet.Requests;

namespace ArgoCD.Client.Internal.Builders
{

    internal class ApplicationSetListQueryBuilder : QueryBuilder<ApplicationSetListQueryOptions>
    {
        public ApplicationSetListQueryBuilder() { }

        protected override void BuildCore(Query query, ApplicationSetListQueryOptions options)
        {
            if (options.Selector.IsNotNullOrEmpty())
                query.Add("selector", options.Selector);

            if (options.AppsetNamespace.IsNotNullOrEmpty())
                query.Add("appsetNamespace", options.AppsetNamespace);

            foreach (string item in options.Projects)
            {
                query.Add("projects",item);
            }

        }
    }
}
