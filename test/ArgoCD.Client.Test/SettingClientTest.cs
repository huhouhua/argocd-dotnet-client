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

﻿using System.IO;
using System.Text;
using System.Threading.Tasks;
using ArgoCD.Client.Impl;
using ArgoCD.Client.Internal.Http.Serialization;
using ArgoCD.Client.Models.Settings.Responses;
using ArgoCD.Client.Test.Utilities;
using FluentAssertions;
using static ArgoCD.Client.Test.Utilities.ArgoCDApiHelper;

namespace ArgoCD.Client.Test;

[Trait("Category", "LinuxIntegration")]
[Collection("ArgoCDKubernetesFixture")]
public class SettingClientTest
{
    private readonly ISettingsClient _client = new SettingsClient(GetFacade());


    [Fact]
    public async Task PluginsCanBeRetrieved()
    {
        var plugins = await _client.GetPluginsAsync();
        plugins.Should().NotBeNull();
        plugins.Should().BeEquivalentTo(new ClusterSettingsPlugins());
    }

    [Fact]
    public async Task SettingsCanBeRetrieved()
    {
        string clusterSettings =
            await File.ReadAllTextAsync(Path.Combine(TestDataBasePath, "settings.json"), Encoding.UTF8);
        var expected = JsonSerializer.Deserialize<ClusterSettings>(clusterSettings);
        var actual = await _client.GetSettingsAsync();
        actual.Should().BeEquivalentTo(expected);
    }
}
