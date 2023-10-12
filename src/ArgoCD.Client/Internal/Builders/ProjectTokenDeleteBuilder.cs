using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Project.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal class ProjectTokenDeleteBuilder : QueryBuilder<DeleteProjectTokenOptions>
    {
        public ProjectTokenDeleteBuilder() { }

        protected override void BuildCore(Query query, DeleteProjectTokenOptions options)
        {
            if (options.Id.IsNotNullOrEmpty())
                query.Add("id",options.Id);

        }
    }
}
