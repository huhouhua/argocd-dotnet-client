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
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using ArgoCD.Client.Internal.Utilities;
using ArgoCD.Client.Models;

namespace ArgoCD.Client.Internal.Builders
{
    internal abstract class QueryBuilder<T>
    {
        protected class Query
        {
            private readonly NameValueCollection _nameValues = new NameValueCollection();

            public void Add(string name, string value)
            {
               if(name.IsNotNullOrEmpty())
                _nameValues.Add(name, value);
            }

            public void Add(string name, bool value)
                => Add(name, value.ToLowerCaseString());

            public void Add(string name, int value)
                => Add(name, value.ToLowerCaseString());

            public void Add(string name, DateTime value)
                => Add(name, value.ToString("o"));

            public void Add(string name, IList<string> values)
            {
                if (name.IsNullOrEmpty() ||  values == null  ||   !values.Any())
                    return;
                foreach (string item in values)
                {
                    if(item.IsNotNullOrEmpty())
                    Add(name, item);
                }
            }

            public void Add(string name, IList<int> values)
            {
                if (name.IsNullOrEmpty() ||  values == null)
                    return;

                foreach (int val in values)
                    Add($"{name}[]", val.ToString());
            }

            public void Add(IList<int> values)
            {
                if (values == null)
                    return;

                foreach (int iid in values)
                    Add("iids[]", iid.ToString());
            }

            public string ToQueryString()
            {
                string[] array = _nameValues.AllKeys.SelectMany(
                        key => _nameValues.GetValues(key)
                            ?.Select(value => $"{key.UrlEncode()}={value.UrlEncode()}")
                    )
                    .ToArray();
                return array.Any() ? string.Concat("?", string.Join("&", array)) : "";
            }
        }

        public string Build(string baseUrl, T options)
        {
            var query = new Query();
            BuildCore(query, options);
            return string.Concat(baseUrl, query.ToQueryString());
        }

        protected abstract void BuildCore(Query query, T options);
    }
}
