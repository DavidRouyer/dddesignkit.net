using Dddesignkit.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// A connection for making HTTP requests against URI endpoints.
    /// </summary>
    public class Connection : IConnection
    {
        static readonly Uri _defaultDribbbleApiUrl = DribbbleClient.DribbbleApiUrl;
        static readonly ICredentialStore _anonymousCredentials = new InMemoryCredentialStore(Credentials.Anonymous);

        readonly Authenticator _authenticator;
        readonly JsonHttpPipeline _jsonPipeline;
        readonly IHttpClient _httpClient;

        public Connection(ProductHeaderValue productInformation)
            : this(productInformation, _defaultDribbbleApiUrl, _anonymousCredentials)
        {
        }

        public Connection(ProductHeaderValue productInformation, IHttpClient httpClient)
            : this(productInformation, _defaultDribbbleApiUrl, _anonymousCredentials, httpClient)
        {
        }

        public Connection(ProductHeaderValue productInformation, Uri baseAddress)
            : this(productInformation, baseAddress, _anonymousCredentials)
        {
        }

        public Connection(ProductHeaderValue productInformation, ICredentialStore credentialStore)
            : this(productInformation, _defaultDribbbleApiUrl, credentialStore)
        {
        }

        public Connection(ProductHeaderValue productInformation, Uri baseAddress, ICredentialStore credentialStore)
            : this(productInformation, baseAddress, credentialStore, new HttpClientAdapter())
        {
        }

        public Connection(
            ProductHeaderValue productInformation,
            Uri baseAddress,
            ICredentialStore credentialStore,
            IHttpClient httpClient)
        {
            Ensure.ArgumentNotNull(productInformation, "productInformation");
            Ensure.ArgumentNotNull(baseAddress, "baseAddress");
            Ensure.ArgumentNotNull(credentialStore, "credentialStore");
            Ensure.ArgumentNotNull(httpClient, "httpClient");

            if (!baseAddress.IsAbsoluteUri)
            {
                throw new ArgumentException(
                    String.Format(CultureInfo.InvariantCulture, "The base address '{0}' must be an absolute URI",
                        baseAddress), "baseAddress");
            }

            UserAgent = FormatUserAgent(productInformation);
            BaseAddress = baseAddress;
            _authenticator = new Authenticator(credentialStore);
            _httpClient = httpClient;
            _jsonPipeline = new JsonHttpPipeline();
        }

        public Task<IApiResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            return SendData<T>(uri.ApplyParameters(parameters), HttpMethod.Get, null, accepts, null, CancellationToken.None);
        }

        public Task<IApiResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts, CancellationToken cancellationToken)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            return SendData<T>(uri.ApplyParameters(parameters), HttpMethod.Get, null, accepts, null, cancellationToken);
        }

        public Task<IApiResponse<T>> Put<T>(Uri uri, object body)
        {
            return SendData<T>(uri, HttpMethod.Put, body, null, null, CancellationToken.None);
        }

        Task<IApiResponse<T>> SendData<T>(
            Uri uri,
            HttpMethod method,
            object body,
            string accepts,
            string contentType,
            TimeSpan timeout,
            CancellationToken cancellationToken,
            string twoFactorAuthenticationCode = null,
            Uri baseAddress = null)
        {
            Ensure.ArgumentNotNull(uri, "uri");
            Ensure.GreaterThanZero(timeout, "timeout");

            var request = new Request
            {
                Method = method,
                BaseAddress = baseAddress ?? BaseAddress,
                Endpoint = uri,
                Timeout = timeout
            };

            return SendDataInternal<T>(body, accepts, contentType, cancellationToken, request);
        }

        Task<IApiResponse<T>> SendData<T>(
            Uri uri,
            HttpMethod method,
            object body,
            string accepts,
            string contentType,
            CancellationToken cancellationToken,
            Uri baseAddress = null)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            var request = new Request
            {
                Method = method,
                BaseAddress = baseAddress ?? BaseAddress,
                Endpoint = uri,
            };

            return SendDataInternal<T>(body, accepts, contentType, cancellationToken, request);
        }

        Task<IApiResponse<T>> SendDataInternal<T>(object body, string accepts, string contentType, CancellationToken cancellationToken, Request request)
        {
            if (!String.IsNullOrEmpty(accepts))
            {
                request.Headers["Accept"] = accepts;
            }

            if (body != null)
            {
                request.Body = body;
                request.ContentType = contentType ?? "application/x-www-form-urlencoded";
            }

            return Run<T>(request, cancellationToken);
        }

        /// <summary>
        /// Performs an asynchronous HTTP PUT request that expects an empty response.
        /// </summary>
        /// <param name="uri">URI endpoint to send request to</param>
        /// <returns>The returned <seealso cref="HttpStatusCode"/></returns>
        public async Task<HttpStatusCode> Put(Uri uri)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            var request = new Request
            {
                Method = HttpMethod.Put,
                BaseAddress = BaseAddress,
                Endpoint = uri
            };
            var response = await Run<object>(request, CancellationToken.None);
            return response.HttpResponse.StatusCode;
        }

        /// <summary>
        /// Performs an asynchronous HTTP DELETE request that expects an empty response.
        /// </summary>
        /// <param name="uri">URI endpoint to send request to</param>
        /// <returns>The returned <seealso cref="HttpStatusCode"/></returns>
        public async Task<HttpStatusCode> Delete(Uri uri)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            var request = new Request
            {
                Method = HttpMethod.Delete,
                BaseAddress = BaseAddress,
                Endpoint = uri
            };
            var response = await Run<object>(request, CancellationToken.None);
            return response.HttpResponse.StatusCode;
        }

        /// <summary>
        /// Performs an asynchronous HTTP DELETE request that expects an empty response.
        /// </summary>
        /// <param name="uri">URI endpoint to send request to</param>
        /// <param name="data">The object to serialize as the body of the request</param>
        /// <returns>The returned <seealso cref="HttpStatusCode"/></returns>
        public async Task<HttpStatusCode> Delete(Uri uri, object data)
        {
            Ensure.ArgumentNotNull(uri, "uri");
            Ensure.ArgumentNotNull(data, "data");

            var request = new Request
            {
                Method = HttpMethod.Delete,
                Body = data,
                BaseAddress = BaseAddress,
                Endpoint = uri
            };
            var response = await Run<object>(request, CancellationToken.None);
            return response.HttpResponse.StatusCode;
        }

        async Task<IApiResponse<T>> Run<T>(IRequest request, CancellationToken cancellationToken)
        {
            _jsonPipeline.SerializeRequest(request);
            var response = await RunRequest(request, cancellationToken).ConfigureAwait(false);
            return _jsonPipeline.DeserializeResponse<T>(response);
        }

        async Task<IResponse> RunRequest(IRequest request, CancellationToken cancellationToken)
        {
            request.Headers.Add("User-Agent", UserAgent);
            await _authenticator.Apply(request).ConfigureAwait(false);
            var response = await _httpClient.Send(request, cancellationToken).ConfigureAwait(false);
            HandleErrors(response);
            return response;
        }

        static void HandleErrors(IResponse response)
        {
            Func<IResponse, Exception> exceptionFunc;
            if (_httpExceptionMap.TryGetValue(response.StatusCode, out exceptionFunc))
            {
                throw exceptionFunc(response);
            }

            if ((int)response.StatusCode >= 400)
            {
                throw new ApiException(response);
            }
        }

        static readonly Dictionary<HttpStatusCode, Func<IResponse, Exception>> _httpExceptionMap =
    new Dictionary<HttpStatusCode, Func<IResponse, Exception>>
            {
                { HttpStatusCode.Unauthorized, GetExceptionForUnauthorized },
                { HttpStatusCode.Forbidden, GetExceptionForForbidden },
                { HttpStatusCode.NotFound, response => new NotFoundException(response) }/*,
                { (HttpStatusCode)422, response => new ApiValidationException(response) }*/
            };

        static Exception GetExceptionForUnauthorized(IResponse response)
        {

            return new AuthorizationException(response);
        }

        static Exception GetExceptionForForbidden(IResponse response)
        {
            string body = response.Body as string ?? "";
            return body.Contains("rate limit exceeded")
                ? new RateLimitExceededException(response)
                : body.Contains("number of login attempts exceeded")
                    ? new ForbiddenException(response)//new LoginAttemptsExceededException(response)
                    : new ForbiddenException(response);
        }

        public Uri BaseAddress { get; private set; }

        public string UserAgent { get; private set; }

        /// <summary>
        /// Gets the <seealso cref="ICredentialStore"/> used to provide credentials for the connection.
        /// </summary>
        public ICredentialStore CredentialStore
        {
            get { return _authenticator.CredentialStore; }
        }

        /// <summary>
        /// Gets or sets the credentials used by the connection.
        /// </summary>
        /// <remarks>
        /// You can use this property if you only have a single hard-coded credential. Otherwise, pass in an 
        /// <see cref="ICredentialStore"/> to the constructor. 
        /// Setting this property will change the <see cref="ICredentialStore"/> to use 
        /// the default <see cref="InMemoryCredentialStore"/> with just these credentials.
        /// </remarks>
        public Credentials Credentials
        {
            get
            {
                var credentialTask = CredentialStore.GetCredentials();
                if (credentialTask == null) return Credentials.Anonymous;
                return credentialTask.Result ?? Credentials.Anonymous;
            }
            // Note this is for convenience. We probably shouldn't allow this to be mutable.
            set
            {
                Ensure.ArgumentNotNull(value, "value");
                _authenticator.CredentialStore = new InMemoryCredentialStore(value);
            }
        }

        static string FormatUserAgent(ProductHeaderValue productInformation)
        {
            return string.Format(CultureInfo.InvariantCulture,
                "{0} ({1} {2}; {3}; {4}; DddesignkitTests {5})",
                productInformation,
#if NETFX_CORE
                // Microsoft doesn't want you changing your Windows Store Application based on the processor or
                // Windows version. If we really wanted this information, we could do a best guess based on
                // this approach: http://attackpattern.com/2013/03/device-information-in-windows-8-store-apps/
                // But I don't think we care all that much.
                "WindowsRT",
                "8+",
                "unknown",
#else
                Environment.OSVersion.Platform,
                Environment.OSVersion.Version.ToString(3),
                Environment.Is64BitOperatingSystem ? "amd64" : "x86",
#endif
                CultureInfo.CurrentCulture.Name,
                AssemblyVersionInformation.Version);
        }
    }
}
