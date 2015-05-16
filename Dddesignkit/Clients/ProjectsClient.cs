using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A client for Dribbble's Projects API
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.dribbble.com/v1/projects/">Projects API documentation</a> for more information.
    ///</remarks>
    public class ProjectsClient : ApiClient, IProjectsClient
    {
        static readonly Uri _projectEndpoint = new Uri("projects", UriKind.Relative);

        /// <summary>
        /// Initializes a new Dribbble Projects API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public ProjectsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Returns the project specified by the id.
        /// </summary>
        /// <param name="id">The id for the project</param>
        public Task<Project> Get(int id)
        {
            var endpoint = "projects/{0}".FormatUri(id);
            return ApiConnection.Get<Project>(endpoint);
        }
    }
}
