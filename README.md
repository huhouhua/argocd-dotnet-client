# ArgoCD .NET Client
![workflow ci](https://github.com/huhouhua/argocd-dotnet-client/actions/workflows/dotnet.yml/badge.svg)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/huhouhua/argocd-dotnet-client/blob/main/LICENSE)
[![Test Coverage](https://codecov.io/gh/huhouhua/argocd-dotnet-client/branch/main/graph/badge.svg)](https://codecov.io/gh/huhouhua/argocd-dotnet-client)

> `argocd-dotnet-client` is a .NET REST client designed for ArgoCD API v1. It allows .NET applications to interact with ArgoCD instances,
> performing various operations such as managing applications, clusters, projects, user sessions, and more. This client aims to simplify
> the integration with ArgoCD within the .NET ecosystem, providing developers with a type-safe and easy-to-use interface to automate and manage ArgoCD resources.


## Features

`argocd-dotnet-client` provides comprehensive support for ArgoCD API v1, with key features including:

- Version Management: Access ArgoCD's version information.
- System Settings: Manage ArgoCD's system configurations and settings.
- Notification Service: Interact with ArgoCD's notification system.
- Account Management: Handle user account and authentication-related operations.
- Session Management: Create and manage user sessions.
- Cluster Management: Register, update, and delete Kubernetes clusters.
- Certificate Management: Manage TLS certificates used by ArgoCD for cluster communication.
- GPG Key Management: Manage GPG keys used for signing and verifying Git commits.
- Repository Credential Management: Configure and manage access credentials for Git repositories.
- Repository Management: Add, update, and delete Git repositories.
- Application Management: Create, deploy, synchronize, and manage ArgoCD applications.
- ApplicationSet Management: Manage ArgoCD ApplicationSets.
- Project Management: Define and manage ArgoCD projects, including resource limits and role bindings.
- Strongly-Typed Client: Provides type-safe C# interfaces, simplifying API calls.
- RESTful Architecture: Designed based on RESTful principles, easy to understand and integrate.


## Installation

Since `argocd-dotnet-client` is a .NET client library, you can add it to your .NET project via the NuGet package manager. Currently, this project has not been published to the official NuGet feed, so you may need to reference it as a local package or build it from source.

**Building from Source (Recommended for Development):**

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/huhouhua/argocd-dotnet-client.git
    cd argocd-dotnet-client
    ```
2.  **Build the project:**
    ```bash
    dotnet build
    ```

**Via NuGet Package Manager (To be published):**

Once published to NuGet, you can install it using the following command:

```bash
dotnet add package ArgoCD.Client
```

##  Quick Start

The following is a simple example demonstrating how to connect to an ArgoCD instance using `argocd-dotnet-client` and retrieve version information. Please note that you need to replace `your_argocd_url` and `your_auth_token` with your actual values.

First, you need to create an `ArgoCDClient` instance:

### Authentication
- if you have auth token:
```csharp
var client =  new ArgoCDClient("https://argocd.example.com", "your_auth_token");
```

## Examples
```csharp
using ArgoCD.Client;
using ArgoCD.Client.Models.Version.Responses;
using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        string argocdUrl = "https://argocd.example.com"; // Replace with your ArgoCD instance URL
        string authToken = "your_auth_token"; // Replace with your authentication token

        // Create ArgoCD client instance
        IArgoCDClient argoCDClient = new ArgoCDClient(argocdUrl, authToken);

        // Get ArgoCD version information
        1VersionMessage version = await argoCDClient.Version.GetVersionAsync();

        Console.WriteLine($"ArgoCD Version: {version.BuildDate}");
        Console.WriteLine($"ArgoCD Git Commit: {version.GitCommit}");
        Console.WriteLine($"ArgoCD Go Version: {version.GoVersion}");
    }
}
```

**More Usage:**

The `IArgoCDClient` interface provides access to various ArgoCD APIs. You can call the corresponding client interfaces as needed to perform operations, for example:

*   **Application Management:** `argoCDClient.Application.CreateAsync(...)`, `argoCDClient.Application.GetAsync(...)`, `argoCDClient.Application.SyncAsync(...)`
*   **Cluster Management:** `argoCDClient.Cluster.CreateAsync(...)`, `argoCDClient.Cluster.DeleteAsync(...)`
*   **Project Management:** `argoCDClient.Project.CreateAsync(...)`, `argoCDClient.Project.GetAsync(...)`

Please refer to the interface definition files (`IAccountClient.cs`, `IApplicationClient.cs`, etc.) in the `src/ArgoCD.Client` directory for all available methods and parameters.


## TODOs

- This library is still in the development stage, and most of the resources are not completed test. Everyone contribute is very much needed. 🙋‍♂️

## Issues

If you have an issue: report it on the [issue tracker](https://github.com/huhouhua/argocd-dotnet-client/issues)


##  License

Licensed under the MIT License. See [LICENSE](LICENSE) for details.
