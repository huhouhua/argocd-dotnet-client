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

﻿using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Builders;
using FluentAssertions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class ApplicationSetClientTest : IAsyncLifetime
{
    private readonly IApplicationSetClient _client = new ApplicationSetClient(GetFacade(),
        new UpsertBuilder(),
        new ApplicationSetQueryBuilder(),
        new ApplicationSetListQueryBuilder());


    public Task InitializeAsync() => CleanupApplicationSets();

    public Task DisposeAsync() => CleanupApplicationSets();

    private async Task CleanupApplicationSets()
    {
        await Task.CompletedTask;
    }
}
