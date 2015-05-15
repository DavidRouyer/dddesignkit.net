using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A client for Dribbble's User Buckets API
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.dribbble.com/v1/users/buckets/">Buckets API documentation</a> for more information.
    ///</remarks>
    public class UserBucketsClient : ApiClient, IUserBucketsClient
    {
        /// <summary>
        /// Initializes a new Dribbble User Buckets API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public UserBucketsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Get all shots owned by the user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Bucket}"/> of <see cref="Bucket"/>.</returns>
        public Task<IReadOnlyList<Bucket>> GetAllBuckets(string username)
        {
            Ensure.ArgumentNotNullOrEmptyString(username, "username");

            return ApiConnection.GetAll<Bucket>(ApiUrls.Buckets(username));
        }

        /// <summary>
        /// Get all shots owned by the current user.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyPagedCollection{Bucket}"/> of <see cref="Bucket"/>.</returns>
        public Task<IReadOnlyList<Bucket>> GetAllBucketsForCurrent()
        {
            return ApiConnection.GetAll<Bucket>(ApiUrls.Buckets());
        }
    }
}
