using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ArgoCD.Client
{
    public interface IArgoCDHttpFacade
    {

        Task<T> GetAsync<T>(string uri, CancellationToken cancellationToken = default);

        Task<T> PostAsync<T>(string uri, object data = null, CancellationToken cancellationToken = default) where T : class;

        Task PostAsync(string uri, object data = null, CancellationToken cancellationToken = default);

        Task<T> PutAsync<T>(string uri, object data, CancellationToken cancellationToken = default);

        Task PutAsync(string uri, object data, CancellationToken cancellationToken = default);

        Task DeleteAsync(string uri, CancellationToken cancellationToken = default);

        Task<T> DeleteAsync<T>(string uri, CancellationToken cancellationToken = default);

        Task DeleteAsync(string uri, object data, CancellationToken cancellationToken = default);
    }
}
