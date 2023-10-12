using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Repository.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ValidateAccessBuilder : QueryBuilder<ValidateAccessOptions>
    {
        protected override void BuildCore(Query query, ValidateAccessOptions options)
        {
            query.Add("insecure", options.Insecure.ToLowerCaseString());
            query.Add("enableOci", options.EnableOCI.ToLowerCaseString());
            query.Add("forceHttpBasicAuth", options.ForceHttpBasicAuth.ToLowerCaseString());

            if (options.Username.IsNotNullOrEmpty())
                query.Add("username",options.Username);

            if (options.Password.IsNotNullOrEmpty())
                query.Add("password", options.Password);

            if (options.SshPrivateKey.IsNotNullOrEmpty())
                query.Add("sshPrivateKey", options.SshPrivateKey);

            if (options.TlsClientCertData.IsNotNullOrEmpty())
                query.Add("tlsClientCertData", options.TlsClientCertData);

            if (options.TlsClientCertKey.IsNotNullOrEmpty())
                query.Add("tlsClientCertKey", options.TlsClientCertKey);

            if (options.Name.IsNotNullOrEmpty())
                query.Add("name", options.Name);

            if (options.GithubAppPrivateKey.IsNotNullOrEmpty())
                query.Add("githubAppPrivateKey", options.GithubAppPrivateKey);

            if (options.GithubAppID.IsNotNullOrEmpty())
                query.Add("githubAppID", options.GithubAppID);

            if (options.GithubAppInstallationID.IsNotNullOrEmpty())
                query.Add("githubAppInstallationID", options.GithubAppInstallationID);

            if (options.GithubAppEnterpriseBaseUrl.IsNotNullOrEmpty())
                query.Add("githubAppEnterpriseBaseUrl", options.GithubAppEnterpriseBaseUrl);

            if (options.Proxy.IsNotNullOrEmpty())
                query.Add("proxy", options.Proxy);

            if (options.Project.IsNotNullOrEmpty())
                query.Add("project", options.Project);

            if (options.GcpServiceAccountKey.IsNotNullOrEmpty())
                query.Add("gcpServiceAccountKey", options.GcpServiceAccountKey);
        }
    }
}
