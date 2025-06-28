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
using System.IO;
using System.Linq;
using System.Text;

namespace ArgoCD.Client.Internal.Utilities
{
    internal static class Guard
    {
        public static void PathExists(string arg, string argName)
        {
            if (string.IsNullOrEmpty(arg) || !(File.Exists(arg) || Directory.Exists(arg)))
                throw new ArgumentException($"ArgumentException: Path not valid {arg}. Parameter name {argName}");
        }

        public static void NotEmpty(string arg, string argName, string message = null)
        {
            if (!string.IsNullOrEmpty(arg))
                return;

            if (string.IsNullOrEmpty(message))
                throw new ArgumentException($"ArgumentException: {argName} string not valid.");

            throw new ArgumentException($"{message}");
        }

        public static void NotNullOrDefault<T>(T arg, string argName)
        {
            if (Equals(arg, default(T)))
                throw new ArgumentException($"ArgumentException: {argName} string not valid.");
        }

        public static void NotEmpty<T>(IEnumerable<T> arg, string argName)
        {
            if (arg == null || !arg.Any())
                throw new ArgumentException($"ArgumentException: sequence {argName} is empty or null");
        }

        public static void NotNull<T>(T arg, string argName)
            where T : class
        {
            if (arg == null)
                throw new ArgumentException($"ArgumentException: {argName} is null");
        }

        public static void IsTrue(bool condition, string message)
        {
            if (!condition)
                throw new ArgumentException($"condition not satisfied: {message}");
        }
    }
}
