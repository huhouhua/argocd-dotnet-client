using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Notification.Responses;

namespace ArgoCD.Client
{
    public interface INotificationClient
    {
        /// <summary>
        ///List returns list of services
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<NotificationServiceList> GetServiceByListAsync(CancellationToken cancellationToken = default);



        /// <summary>
        ///List returns list of templates
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<NotificationServiceList> GetTemplateByListAsync(CancellationToken cancellationToken = default);



        /// <summary>
        ///List returns list of triggers
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<NotificationServiceList> GetTriggersByListAsync(CancellationToken cancellationToken = default);

    }
}
