using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A connection for making API requests against URI endpoints.
    /// Provides type-friendly convenience methods that wrap <see cref="IConnection"/> methods.
    /// </summary>
    public interface IApiConnection
    {
        /// <summary>
        /// The underlying connection.
        /// </summary>
        IConnection Connection { get; }

        /// <summary>
        /// Gets the API resource at the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the API resource to get.</typeparam>
        /// <param name="uri">URI of the API resource to get</param>
        /// <param name="parameters">Parameters to add to the API request</param>
        /// <returns>The API resource.</returns>
        /// <exception cref="ApiException">Thrown when an API error occurs.</exception>
        Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters);

        /// <summary>
        /// Gets the API resource at the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the API resource to get.</typeparam>
        /// <param name="uri">URI of the API resource to get</param>
        /// <param name="parameters">Parameters to add to the API request</param>
        /// <param name="accepts">Accept header to use for the API request</param>
        /// <returns>The API resource.</returns>
        /// <exception cref="ApiException">Thrown when an API error occurs.</exception>
        Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts);

        /// <summary>
        /// Gets all API resources in the list at the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the API resource in the list.</typeparam>
        /// <param name="uri">URI of the API resource to get</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list.</returns>
        /// <exception cref="ApiException">Thrown when an API error occurs.</exception>
        Task<IReadOnlyList<T>> GetAll<T>(Uri uri);

        /// <summary>
        /// Gets all API resources in the list at the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the API resource in the list.</typeparam>
        /// <param name="uri">URI of the API resource to get</param>
        /// <param name="parameters">Parameters to add to the API request</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list.</returns>
        /// <exception cref="ApiException">Thrown when an API error occurs.</exception>
        Task<IReadOnlyList<T>> GetAll<T>(Uri uri, IDictionary<string, string> parameters);

        /// <summary>
        /// Creates or replaces the API resource at the specified URI
        /// </summary>
        /// <param name="uri">URI of the API resource to put</param>
        /// <returns>A <see cref="Task"/> for the request's execution.</returns>
        Task Put(Uri uri);

        /// <summary>
        /// Creates or replaces the API resource at the specified URI.
        /// </summary>
        /// <typeparam name="T">The API resource's type.</typeparam>
        /// <param name="uri">URI of the API resource to create or replace</param>
        /// <param name="data">Object that describes the API resource; this will be serialized and used as the request's body</param>
        /// <returns>The created API resource.</returns>
        /// <exception cref="ApiException">Thrown when an API error occurs.</exception>
        Task<T> Put<T>(Uri uri, object data);

        /// <summary>
        /// Deletes the API object at the specified URI.
        /// </summary>
        /// <param name="uri">URI of the API resource to delete</param>
        /// <returns>A <see cref="Task"/> for the request's execution.</returns>
        Task Delete(Uri uri);

        /// <summary>
        /// Deletes the API object at the specified URI.
        /// </summary>
        /// <param name="uri">URI of the API resource to delete</param>
        /// <param name="data">Object that describes the API resource; this will be serialized and used as the request's body</param>
        /// <returns>A <see cref="Task"/> for the request's execution.</returns>
        Task Delete(Uri uri, object data);
    }
}
