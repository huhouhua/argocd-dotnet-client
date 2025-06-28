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
using Newtonsoft.Json;

namespace ArgoCD.Client.Internal.Http.Serialization
{
    internal class CollectionToCommaSeparatedValuesConverter: JsonConverter
    {
        public override bool CanRead { get; } = false;

        public override bool CanConvert(Type objectType) =>
            objectType == typeof(IEnumerable<string>);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            writer.WriteValue(string.Join(",", (IEnumerable<string>)value));

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
            throw new NotSupportedException();
    }
}
