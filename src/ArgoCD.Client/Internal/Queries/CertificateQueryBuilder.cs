using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Certificate.Requests;

namespace ArgoCD.Client.Internal.Queries
{
    internal class CertificateQueryBuilder : QueryBuilder<CertificateQueryOptions>
    {
        protected override void BuildCore(Query query, CertificateQueryOptions options)
        {

            if (options.HostNamePattern.IsNotNullOrEmpty())
                query.Add("hostNamePattern", options.HostNamePattern);

            if (options.CertType.IsNotNullOrEmpty())
                query.Add("certType", options.CertType);

            if (options.CertSubType.IsNotNullOrEmpty())
                query.Add("certSubType", options.CertSubType);

        }
    }
}
