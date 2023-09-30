using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ArgoCD.Client.Models
{
    public sealed class VersionInfo
    {
        public string BuildDate { get; set; }
        public string Compiler { get; set; }
        public string GitCommit { get; set; }
        public string GitTag { get; set; }
        public string GitTreeState { get; set; }
        public string GoVersion { get; set; }
        public string HelmVersion { get; set; }
        public string JsonnetVersion { get; set; }
        public string KubectlVersion { get; set; }
        public string KustomizeVersion { get; set; }
        public string Platform { get; set; }
        public string Version { get; set; }
    }
}
