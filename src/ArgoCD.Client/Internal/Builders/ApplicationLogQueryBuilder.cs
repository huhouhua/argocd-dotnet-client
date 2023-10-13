using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Application.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ApplicationLogQueryBuilder : QueryBuilder<ApplicationLogQueryOptions>
    {
        protected override void BuildCore(Query query, ApplicationLogQueryOptions options)
        {
            if (options.Namespace.IsNotNullOrEmpty())
                query.Add("namespace",options.Namespace);

            if (options.PodName.IsNotNullOrEmpty())
                query.Add("podName", options.PodName);

            if (options.Container.IsNotNullOrEmpty())
                query.Add("container", options.Container);

            if (options.SinceSeconds.IsNotNullOrEmpty())
                query.Add("sinceSeconds", options.SinceSeconds);

            if (options.SinceTimeFromSeconds.IsNotNullOrEmpty())
                query.Add("sinceTime.seconds", options.SinceTimeFromSeconds);

              query.Add("sinceTime.nanos", options.SinceTimeFromNanos);

            if (options.TailLines.IsNotNullOrEmpty())
                query.Add("tailLines", options.TailLines);

            query.Add("follow", options.Follow.ToLowerCaseString());

            if (options.UntilTime.IsNotNullOrEmpty())
                query.Add("untilTime", options.UntilTime);

            if (options.Filter.IsNotNullOrEmpty())
                query.Add("filter", options.Filter);

            if (options.Kind.IsNotNullOrEmpty())
                query.Add("kind", options.Kind);

            if (options.Group.IsNotNullOrEmpty())
                query.Add("group", options.Group);

            if (options.ResourceName.IsNotNullOrEmpty())
                query.Add("resourceName", options.ResourceName);

            query.Add("previous", options.Previous.ToLowerCaseString());

            if (options.AppNamespace.IsNotNullOrEmpty())
                query.Add("appNamespace", options.AppNamespace);

            if (options.Project.IsNotNullOrEmpty())
                query.Add("project", options.Project);
        }
    }
}
