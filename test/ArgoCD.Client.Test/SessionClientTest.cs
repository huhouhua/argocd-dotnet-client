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

﻿using System;
using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Models.Session.Responses;
using ArgoCD.Client.Test.Utilities;
using FluentAssertions;
using Xunit.Abstractions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class SessionClientTest
{
    private readonly ISessionClient _client = new SessionClient(GetFacade());

    [Fact]
    public async Task CurrentUserSessionCanBeRetrieved()
    {
        var userInfo = await _client.GetCurrentUserInfoAsync();
        userInfo.LoggedIn.Should().BeTrue();
        userInfo.Username.Should().Be(TestUserNameWithAdmin);
        userInfo.Iss.Should().Be(TestIss);
    }

    [Fact]
    public async Task DeleteSessionCanBeRetrieved()
    {
       var action = async () => await _client.DeleteCurrentSessionAsync();
        await action.Should().NotThrowAsync();
    }
}
