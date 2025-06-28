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
