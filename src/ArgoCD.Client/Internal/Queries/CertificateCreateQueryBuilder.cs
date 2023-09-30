using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Certificate.Requests;

namespace ArgoCD.Client.Internal.Queries
{

    internal class CertificateCreateQueryBuilder : QueryBuilder<CreateCertificateOptions>
    {
        protected override void BuildCore(Query query, CreateCertificateOptions options)
        {
            query.Add("upsert", options.Upsert.ToLowerCaseString());
        }
    }
}
