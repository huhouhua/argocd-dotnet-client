using System;
using System.Collections.Generic;
using System.Text;

namespace ArgoCD.Client.Models.Project.Responses
{
    public class ProjectSyncWindows
    {
        public V1alpha1SyncWindow[] Windows { get; set; }
    }
}
