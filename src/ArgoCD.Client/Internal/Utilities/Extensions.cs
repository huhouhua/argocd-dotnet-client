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
using System.Linq;
using System.Text;

namespace ArgoCD.Client.Internal.Utilities
{
    internal static class Extensions
    {
        public static bool IsNullOrEmpty(this string value) =>
        string.IsNullOrEmpty(value);

        public static bool IsNotNullOrEmpty(this string value) =>
            !value.IsNullOrEmpty();

        public static string ToLowerCaseString(this object obj) =>
            obj.ToString().ToLowerInvariant();

        /// <summary>
        /// URL encodes a string unless already URL encoded
        /// </summary>
        /// <param name="value">URL path</param>
        /// <returns>Encoded URL path</returns>
        public static string UrlEncode(this string value) =>
            value.Contains("%") ? value : System.Uri.EscapeDataString(value);

        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var enumType = value.GetType();
            string name = Enum.GetName(enumType, value);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<T>().SingleOrDefault();
        }
    }
}
