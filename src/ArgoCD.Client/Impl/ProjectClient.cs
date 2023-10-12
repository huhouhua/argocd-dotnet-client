using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArgoCD.Client.Models.Project.Responses;
using ArgoCD.Client.Models.Project.Requests;
using ArgoCD.Client.Internal.Queries;
using System.Xml.Linq;
using ArgoCD.Client.Internal.Http;
using ArgoCD.Client.Internal.Utilities;

namespace ArgoCD.Client.Impl
{
    public class ProjectClient : IProjectClient
    {
        private readonly IArgoCDHttpFacade _httpFacade;
        private readonly AppProjectQueryBuilder _appProjectQueryBuilder;
        private readonly ProjectTokenDeleteBuilder _projectTokenDeleteBuilder;

        internal ProjectClient(IArgoCDHttpFacade httpFacade,
            AppProjectQueryBuilder appProjectQueryBuilder,
            ProjectTokenDeleteBuilder projectTokenDeleteBuilder)
        {
            _httpFacade = httpFacade;
            _appProjectQueryBuilder = appProjectQueryBuilder;
            _projectTokenDeleteBuilder = projectTokenDeleteBuilder;
        }

        /// <summary>
        ///  List returns list of projects
        /// </summary>
        /// <param name="options">get options <see cref="AppProjectQueryOptions"/></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1AppProjectList> GetListAsync(Action<AppProjectQueryOptions> options, CancellationToken cancellationToken = default)
        {
            var queryOptions = new AppProjectQueryOptions();
            options?.Invoke(queryOptions);

            string url = _appProjectQueryBuilder.Build("projects", queryOptions);
            return await _httpFacade.GetAsync<V1alpha1AppProjectList>(url, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        ///  Create a new project
        /// </summary>
        ///  <param name="request"> Create project request </param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1AppProject> CreateProjectAsync(CreateProjectRequest request, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));
            return await _httpFacade.PostAsync<V1alpha1AppProject>("projects", request, cancellationToken).
                ConfigureAwait(false);
        }



        /// <summary>
        ///  Get returns a project by name
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1AppProject> GetProjectAsync(string name, CancellationToken cancellationToken = default) =>
             await _httpFacade.GetAsync<V1alpha1AppProject>($"projects/{name}", cancellationToken).
            ConfigureAwait(false);



        /// <summary>
        ///  Delete deletes a project
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task DeleteProjectAsync(string name, CancellationToken cancellationToken = default) =>
              await _httpFacade.DeleteAsync($"projects/{name}", cancellationToken).
            ConfigureAwait(false);



        /// <summary>
        ///  GetProjectDetail returns a project that include project, global project and scoped resources by name
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ProjectDetailedProjects> GetProjectDetailAsync(string name, CancellationToken cancellationToken = default) =>
             await _httpFacade.GetAsync<ProjectDetailedProjects>($"projects/{name}/detailed", cancellationToken).
            ConfigureAwait(false);




        /// <summary>
        ///  GetProjectEventByList returns a project that include project, global project and scoped resources by name
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1EventList> GetProjectEventByListAsync(string name, CancellationToken cancellationToken = default) =>
              await _httpFacade.GetAsync<V1EventList>($"projects/{name}/events", cancellationToken).
            ConfigureAwait(false);



        /// <summary>
        ///  Get returns a virtual project by name
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ProjectGlobalProjects> GetVirtualProjectAsync(string name, CancellationToken cancellationToken = default) =>
             await _httpFacade.GetAsync<ProjectGlobalProjects>($"projects/{name}/globalprojects", cancellationToken).
            ConfigureAwait(false);


        /// <summary>
        /// ListLinks returns all deep links for the particular project
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ApplicationLinks> GetProjectLinksAsync(string name, CancellationToken cancellationToken = default) =>
            await _httpFacade.GetAsync<ApplicationLinks>($"projects/{name}/links", cancellationToken).
            ConfigureAwait(false);


        /// <summary>
        /// GetSchedulesState returns true if there are any active sync syncWindows
        /// </summary>
        /// <param name="name"> project name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ProjectSyncWindows> GetSchedulesStateAsync(string name, CancellationToken cancellationToken = default) =>
            await _httpFacade.GetAsync<ProjectSyncWindows>($"projects/{name}/syncwindows", cancellationToken).
            ConfigureAwait(false);


        /// <summary>
        ///Updates a project
        /// </summary>
        /// <param name="name"> project name</param>
        ///  <param name="request">update project request </param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<V1alpha1AppProject> UpdateProjectAsync(string name, UpdateProjectRequest request, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));

            return await _httpFacade.PutAsync<V1alpha1AppProject>($"projects/{name}", request, cancellationToken).ConfigureAwait(false);
        }



        /// <summary>
        /// Create a new project token
        /// </summary>
        ///  <param name="request">create project a token request </param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task<ProjectToken> CreateProjectTokenAsync(string project, string role, CreateProjectTokenRequest request, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request, nameof(request));

          return  await _httpFacade.PostAsync<ProjectToken>($"projects/{project}/roles/{role}/token", request, cancellationToken).
                ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a new project token
        /// </summary>
        ///  <param name="options">delete project a token request </param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive, notice of cancellation.</param>
        /// <returns></returns>
        public async Task DeleteProjectTokenAsync(string project, string role, string iat, Action<DeleteProjectTokenOptions> options, CancellationToken cancellationToken = default)
        {
            var deleteOptions = new DeleteProjectTokenOptions();
            options?.Invoke(deleteOptions);

            string url = _projectTokenDeleteBuilder.Build($"projects/{project}/roles/{role}/token/{iat}", deleteOptions);
            await _httpFacade.DeleteAsync(url, cancellationToken).
                ConfigureAwait(false);
        }
    }
}
