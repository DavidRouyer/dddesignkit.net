using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A client for Dribbble's Shots API.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.dribbble.com/v1/shots/">Shots API documentation</a> for more information.
    /// </remarks>
    public class ShotsClient : ApiClient, IShotsClient
    {
        static readonly Uri _shotEndpoint = new Uri("shots", UriKind.Relative);

        public ShotsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Shot>> GetAll()
        {
            return ApiConnection.GetAll<Shot>(_shotEndpoint);
        }

        public Task<Shot> Get(int id)
        {
            Ensure.ArgumentNotNull(id, "id");

            var endpoint = "shots/{0}".FormatUri(id);
            return ApiConnection.Get<Shot>(endpoint);
        }
    }
}
