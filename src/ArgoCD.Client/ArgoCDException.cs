using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ArgoCD.Client.Models.Application.Reponses;

namespace ArgoCD.Client
{
    /// <inheritdoc />
    /// <summary>
    /// Exception thrown when ArgoCD returns non success status code.
    /// </summary>
    public class ArgoCDException : Exception
    {
        public ArgoCDException(HttpStatusCode statusCode)
       => HttpStatusCode = statusCode;

        public ArgoCDException(HttpStatusCode statusCode, string message) : base(message)
            => HttpStatusCode = statusCode;

        public ArgoCDException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
            => HttpStatusCode = statusCode;

        public ArgoCDException(HttpStatusCode statusCode, string message, string error, params ProtobufAny[] details) : base(message)
        {
            HttpStatusCode = statusCode;
            Error = error;
            Details = details;
        }

        /// <summary>
        /// Http status code of ArgoCD response.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; }

        public ProtobufAny[] Details { get; }

        public string Error { get; }
    }
}
