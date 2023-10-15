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
                return array.Any() ? "?" + string.Join("&", array) : "";
            }
        }

        public string Build(string baseUrl, T options)
        {
            var query = new Query();
            BuildCore(query, options);
            return string.Concat(baseUrl, query.ToQueryString());
        }

        protected abstract void BuildCore(Query query, T options);

        protected static string GetSortOrderQueryValue(SortOrder order)
        {
            switch (order)
            {
                case SortOrder.Ascending:
                    return "asc";
                case SortOrder.Descending:
                    return "desc";
                default:
                    throw new NotSupportedException($"Order {order} not supported");
            }
        }
    }
}
