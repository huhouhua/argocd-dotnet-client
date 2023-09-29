using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ArgoCD.Client
{
    /// <inheritdoc />
    /// <summary>
    /// Exception thrown when ArgoCD returns non success status code.
    /// </summary>
    public class ArgoCDException: Exception
    {
        public ArgoCDException(HttpStatusCode statusCode)
       => HttpStatusCode = statusCode;

        public ArgoCDException(HttpStatusCode statusCode, string message) : base(message)
            => HttpStatusCode = statusCode;

        public ArgoCDException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
            => HttpStatusCode = statusCode;

        /// <summary>
        /// Http status code of ArgoCD response.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; }
    
}
}
