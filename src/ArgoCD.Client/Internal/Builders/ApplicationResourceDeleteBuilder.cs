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
    internal sealed class ApplicationResourceDeleteBuilder : QueryBuilder<DeleteApplicationResourceOptions>
    {
        protected override void BuildCore(Query query, DeleteApplicationResourceOptions options)
        {
            if (options.Namespace.IsNotNullOrEmpty())
                query.Add("namespace", options.Namespace);

            if (options.ResourceName.IsNotNullOrEmpty())
                query.Add("resourceName", options.ResourceName);

            if (options.Version.IsNotNullOrEmpty())
                query.Add("version", options.Version);

            if (options.Group.IsNotNullOrEmpty())
                query.Add("group", options.Group);

            if (options.Kind.IsNotNullOrEmpty())
                query.Add("kind", options.Kind);

            query.Add("force", options.Force);
            query.Add("orphan", options.Orphan);

            if (options.AppNamespace.IsNotNullOrEmpty())
                query.Add("appNamespace", options.AppNamespace);

            if (options.Project.IsNotNullOrEmpty())
                query.Add("project", options.Project);
        }
    }
}
