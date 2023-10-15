using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Application.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ApplicationCreateOrUpdateBuilder : QueryBuilder<CreateOrUpdateApplicationOptions>
    {
        protected override void BuildCore(Query query, CreateOrUpdateApplicationOptions options)
        {
            query.Add("upsert",options.Upsert);
            query.Add("validate",options.Validate);
        }
    }
}
