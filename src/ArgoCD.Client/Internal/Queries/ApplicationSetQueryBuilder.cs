using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Models.ApplicationSet.Requests;

namespace ArgoCD.Client.Internal.Queries
{

    internal class ApplicationSetQueryBuilder : QueryBuilder<ApplicationSetQueryOptions>
    {
        public ApplicationSetQueryBuilder() { }

        protected override void BuildCore(Query query, ApplicationSetQueryOptions options)
        {
            query.Add("selector", options.Selector);
            query.Add("appsetNamespace", options.AppsetNamespace);

            foreach (string item in options.Projects)
            {
                query.Add("projects",item);
            }

        }
    }
}
