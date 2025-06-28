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
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Project.Responses;
using ArgoCD.Client.Models.Project.Requests;

namespace ArgoCD.Client
{
    public interface IProjectClient
    {
        /// <summary>
        ///  List returns list of projects
        /// </summary>
        /// <param name="options">get options <see cref="AppProjectQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1AppProjectList> GetListAsync(Action<AppProjectQueryOptions> options, CancellationToken cancellationToken = default);


        /// <summary>
        ///  Create a new project
        /// </summary>
        ///  <param name="request"> Create project request </param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1AppProject> CreateProjectAsync(CreateProjectRequest request, CancellationToken cancellationToken = default);



        /// <summary>
        ///  Get returns a project by name
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1AppProject> GetProjectAsync(string name, CancellationToken cancellationToken = default);



        /// <summary>
        ///  Delete deletes a project
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task DeleteProjectAsync(string name, CancellationToken cancellationToken = default);



        /// <summary>
        ///  GetProjectDetail returns a project that include project, global project and scoped resources by name
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ProjectDetailedProjects> GetProjectDetailAsync(string name, CancellationToken cancellationToken = default);



        /// <summary>
        ///  GetProjectEventByList returns a project that include project, global project and scoped resources by name
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1EventList> GetProjectEventByListAsync(string name, CancellationToken cancellationToken = default);



        /// <summary>
        ///  Get returns a virtual project by name
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ProjectGlobalProjects> GetVirtualProjectAsync(string name, CancellationToken cancellationToken = default);


        /// <summary>
        /// ListLinks returns all deep links for the particular project
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ApplicationLinks> GetProjectLinksAsync(string name, CancellationToken cancellationToken = default);


        /// <summary>
        /// GetSchedulesState returns true if there are any active sync syncWindows
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ProjectSyncWindows> GetSchedulesStateAsync(string name, CancellationToken cancellationToken = default);


        /// <summary>
        ///Updates a project
        /// </summary>
        /// <param name="name"> project name</param>
        ///  <param name="request">update project request </param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<V1alpha1AppProject> UpdateProjectAsync(string name, UpdateProjectRequest request, CancellationToken cancellationToken = default);



        /// <summary>
        /// Create a new project token
        /// </summary>
        ///  <param name="request">create project a token request </param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task<ProjectToken> CreateProjectTokenAsync(string project, string role, CreateProjectTokenRequest request, CancellationToken cancellationToken = default);


        /// <summary>
        /// Delete a new project token
        /// </summary>
        ///  <param name="options">delete project a token request </param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        Task DeleteProjectTokenAsync(string project, string role, string iat, Action<DeleteProjectTokenOptions> options, CancellationToken cancellationToken = default);


    }
}
