using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A client for Dribbble's Buckets API
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.dribbble.com/v1/buckets/">Buckets API documentation</a> for more information.
    ///</remarks>
    public class BucketsClient : ApiClient, IBucketsClient
    {
        static readonly Uri _bucketEndpoint = new Uri("buckets", UriKind.Relative);

        /// <summary>
        /// Initializes a new Dribbble Buckets API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public BucketsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Returns the bucket specified by the id.
        /// </summary>
        /// <param name="id">The id for the bucket</param>
        public Task<Bucket> Get(int id)
        {
            var endpoint = "buckets/{0}".FormatUri(id);
            return ApiConnection.Get<Bucket>(endpoint);
        }
    }
}
