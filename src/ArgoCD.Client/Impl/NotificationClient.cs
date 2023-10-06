using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Notification;

namespace ArgoCD.Client.Impl
{
    public sealed class NotificationClient: INotificationClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;

        internal NotificationClient(IArgoCDHttpFacade httpFacade) => _httpFacade = httpFacade;

        /// <summary>
        ///List returns list of services
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<NotificationServiceList> GetServiceByListAsync(CancellationToken cancellationToken = default) =>
           await _httpFacade.GetAsync<NotificationServiceList>("notifications/services", cancellationToken).ConfigureAwait(false);



        /// <summary>
        ///List returns list of templates
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<NotificationServiceList> GetTemplateByListAsync(CancellationToken cancellationToken = default) =>
            await _httpFacade.GetAsync<NotificationServiceList>("notifications/templates", cancellationToken).ConfigureAwait(false);



        /// <summary>
        ///List returns list of triggers
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<NotificationServiceList> GetTriggersByListAsync(CancellationToken cancellationToken = default) =>
            await _httpFacade.GetAsync<NotificationServiceList>("notifications/triggers", cancellationToken).ConfigureAwait(false);
    }
}
