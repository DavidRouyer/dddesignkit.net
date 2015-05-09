using Dddesignkit.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A connection for making API requests against URI endpoints.
    /// Provides type-friendly convenience methods that wrap <see cref="IConnection"/> methods.
    /// </summary>
    public class ApiConnection : IApiConnection
    {
        readonly IApiPagination _pagination;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiConnection"/> class.
        /// </summary>
        /// <param name="connection">A connection for making HTTP requests</param>
        public ApiConnection(IConnection connection) : this(connection, new ApiPagination())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiConnection"/> class.
        /// </summary>
        /// <param name="connection">A connection for making HTTP requests</param>
        /// <param name="pagination">A paginator for paging API responses</param>
        protected ApiConnection(IConnection connection, IApiPagination pagination)
        {
            Ensure.ArgumentNotNull(connection, "connection");
            Ensure.ArgumentNotNull(pagination, "pagination");

            Connection = connection;
            _pagination = pagination;
        }

        public IConnection Connection { get; private set; }

        /// <summary>
        /// Gets the API resource at the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the API resource to get.</typeparam>
        /// <param name="uri">URI of the API resource to get</param>
        /// <param name="parameters">Parameters to add to the API request</param>
        /// <returns>The API resource.</returns>
        /// <exception cref="ApiException">Thrown when an API error occurs.</exception>
        public async Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            var response = await Connection.Get<T>(uri, parameters, null).ConfigureAwait(false);
            return response.Body;
        }

        /// <summary>
        /// Gets the API resource at the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the API resource to get.</typeparam>
        /// <param name="uri">URI of the API resource to get</param>
        /// <param name="parameters">Parameters to add to the API request</param>
        /// <param name="accepts">Accept header to use for the API request</param>
        /// <returns>The API resource.</returns>
        /// <exception cref="ApiException">Thrown when an API error occurs.</exception>
        public async Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts)
        {
            Ensure.ArgumentNotNull(uri, "uri");
            Ensure.ArgumentNotNull(accepts, "accepts");

            var response = await Connection.Get<T>(uri, parameters, accepts).ConfigureAwait(false);
            return response.Body;
        }

        /// <summary>
        /// Gets all API resources in the list at the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the API resource in the list.</typeparam>
        /// <param name="uri">URI of the API resource to get</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list.</returns>
        /// <exception cref="ApiException">Thrown when an API error occurs.</exception>
        public Task<IReadOnlyList<T>> GetAll<T>(Uri uri)
        {
            return GetAll<T>(uri, null, null);
        }

        /// <summary>
        /// Gets all API resources in the list at the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the API resource in the list.</typeparam>
        /// <param name="uri">URI of the API resource to get</param>
        /// <param name="parameters">Parameters to add to the API request</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list.</returns>
        /// <exception cref="ApiException">Thrown when an API error occurs.</exception>
        public Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IDictionary<string, string> parameters)
        {
            return GetAll<T>(uri, parameters, null);
        }

        /// <summary>
        /// Gets all API resources in the list at the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the API resource in the list.</typeparam>
        /// <param name="uri">URI of the API resource to get</param>
        /// <param name="parameters">Parameters to add to the API request</param>
        /// <param name="accepts">Accept header to use for the API request</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list.</returns>
        /// <exception cref="ApiException">Thrown when an API error occurs.</exception>
        public Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IDictionary<string, string> parameters, string accepts)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            return _pagination.GetAllPages(async () => await GetPage<T>(uri, parameters, accepts)
                                                                 .ConfigureAwait(false), uri);
        }

        async Task<IReadOnlyPagedCollection<T>> GetPage<T>(
            Uri uri,
            IDictionary<string, string> parameters,
            string accepts)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            var response = await Connection.Get<List<T>>(uri, parameters, accepts).ConfigureAwait(false);
            return new ReadOnlyPagedCollection<T>(
                response,
                nextPageUri => Connection.Get<List<T>>(nextPageUri, parameters, accepts));
        }
    }
}
