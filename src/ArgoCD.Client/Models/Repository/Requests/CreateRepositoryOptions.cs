using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Repository.Requests
{
    public sealed class CreateRepositoryOptions
    {
        public CreateRepositoryOptions() { }

        /// <summary>
        /// Whether to create in upsert mode.
        /// </summary>
        public bool Upsert { get; set; }

        /// <summary>
        /// Whether to operate on credential set instead of repository.
        /// </summary>
        public bool CredsOnly { get; set; }
    }
}
