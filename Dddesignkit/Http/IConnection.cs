﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A connection for making HTTP requests against URI endpoints.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Performs an asynchronous HTTP GET request.
        /// Attempts to map the response to an object of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type to map the response to</typeparam>
        /// <param name="uri">URI endpoint to send request to</param>
        /// <param name="parameters">Querystring parameters for the request</param>
        /// <param name="accepts">Specifies accepted response media types.</param>
        /// <returns><seealso cref="IResponse"/> representing the received HTTP response</returns>
        Task<IApiResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts);

        /// <summary>
        /// Performs an asynchronous HTTP GET request.
        /// Attempts to map the response to an object of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type to map the response to</typeparam>
        /// <param name="uri">URI endpoint to send request to</param>
        /// <param name="parameters">Querystring parameters for the request</param>
        /// <param name="accepts">Specifies accepted response media types.</param>
        /// <param name="cancellationToken">A token used to cancel the Get request</param>
        /// <returns><seealso cref="IResponse"/> representing the received HTTP response</returns>
        Task<IApiResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts, CancellationToken cancellationToken);

        /// <summary>
        /// Performs an asynchronous HTTP PUT request.
        /// Attempts to map the response body to an object of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type to map the response to</typeparam>
        /// <param name="uri">URI endpoint to send request to</param>
        /// <param name="body">The body of the request</param>
        /// <returns><seealso cref="IResponse"/> representing the received HTTP response</returns>
        Task<IApiResponse<T>> Put<T>(Uri uri, object body);

        /// <summary>
        /// Performs an asynchronous HTTP PUT request that expects an empty response.
        /// </summary>
        /// <param name="uri">URI endpoint to send request to</param>
        /// <returns>The returned <seealso cref="HttpStatusCode"/></returns>
        Task<HttpStatusCode> Put(Uri uri);

        /// <summary>
        /// Performs an asynchronous HTTP DELETE request that expects an empty response.
        /// </summary>
        /// <param name="uri">URI endpoint to send request to</param>
        /// <returns>The returned <seealso cref="HttpStatusCode"/></returns>
        Task<HttpStatusCode> Delete(Uri uri);

        /// <summary>
        /// Performs an asynchronous HTTP DELETE request that expects an empty response.
        /// </summary>
        /// <param name="uri">URI endpoint to send request to</param>
        /// <param name="data">The object to serialize as the body of the request</param>
        /// <returns>The returned <seealso cref="HttpStatusCode"/></returns>
        Task<HttpStatusCode> Delete(Uri uri, object data);

        /// <summary>
        /// Base address for the connection.
        /// </summary>
        Uri BaseAddress { get; }

        /// <summary>
        /// Gets the <seealso cref="ICredentialStore"/> used to provide credentials for the connection.
        /// </summary>
        ICredentialStore CredentialStore { get; }

        /// <summary>
        /// Gets or sets the credentials used by the connection.
        /// </summary>
        /// <remarks>
        /// You can use this property if you only have a single hard-coded credential. Otherwise, pass in an 
        /// <see cref="ICredentialStore"/> to the constructor. 
        /// Setting this property will change the <see cref="ICredentialStore"/> to use 
        /// the default <see cref="InMemoryCredentialStore"/> with just these credentials.
        /// </remarks>
        Credentials Credentials { get; set; }
    }
}
