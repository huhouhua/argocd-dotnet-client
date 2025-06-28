// Copyright 2024 The argocd-dotnet-client Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models.Application.Requests;

namespace ArgoCD.Client.Internal.Builders
{
    internal sealed class ApplicationQueryBuilder : QueryBuilder<ApplicationQueryOptions>
    {

        protected override void BuildCore(Query query, ApplicationQueryOptions options)
        {

            if (options.Refresh.IsNotNullOrEmpty())
                query.Add("refresh", options.Refresh);

            if (options.ResourceVersion.IsNotNullOrEmpty())
                query.Add("resourceVersion", options.ResourceVersion);

            if (options.Selector.IsNotNullOrEmpty())
                query.Add("selector", options.Selector);

            if (options.Repo.IsNotNullOrEmpty())
                query.Add("repo", options.Repo);

            if (options.AppNamespace.IsNotNullOrEmpty())
                query.Add("appNamespace", options.AppNamespace);

            query.Add("projects", options.Projects);
            query.Add("project", options.Project);
        }
    }
}
