using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Application.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ApplicationCreateOrUpdateBuilder : QueryBuilder<CreateApplicationOptions>
    {
        protected override void BuildCore(Query query, CreateApplicationOptions options)
        {
            query.Add("upsert",options.Upsert.ToLowerCaseString());
            query.Add("validate",options.Validate.ToLowerCaseString());
        }
    }
}
