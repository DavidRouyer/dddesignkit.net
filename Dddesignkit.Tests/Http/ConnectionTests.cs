using Dddesignkit.Internal;
using Dddesignkit.Tests.Helpers;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dddesignkit.Tests.Http
{
    public class ConnectionTests
    {
        const string exampleUrl = "http://example.com";
        static readonly Uri _exampleUri = new Uri(exampleUrl);

        public class TheGetMethod
        {
            [Fact]
            public async Task SendsProperlyFormattedRequest()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response();
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("DddesignkitTests"),
                    _exampleUri,
                    Substitute.For<ICredentialStore>(),
                    httpClient);

                await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative));

                httpClient.Received(1).Send(Arg.Is<IRequest>(req =>
                    req.BaseAddress == _exampleUri &&
                    req.ContentType == null &&
                    req.Body == null &&
                    req.Method == HttpMethod.Get &&
                    req.Endpoint == new Uri("endpoint", UriKind.Relative)), Args.CancellationToken);
            }

            [Fact]
            public async Task CanMakeMutipleRequestsWithSameConnection()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response();
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("DddesignkitTests"),
                    _exampleUri,
                    Substitute.For<ICredentialStore>(),
                    httpClient);

                await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative));
                await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative));
                await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative));

                httpClient.Received(3).Send(Arg.Is<IRequest>(req =>
                    req.BaseAddress == _exampleUri &&
                    req.Method == HttpMethod.Get &&
                    req.Endpoint == new Uri("endpoint", UriKind.Relative)), Args.CancellationToken);
            }

            [Fact]
            public async Task ParsesApiInfoOnResponse()
            {
                var httpClient = Substitute.For<IHttpClient>();
                var headers = new Dictionary<string, string>
                {
                    { "X-Accepted-OAuth-Scopes", "user" },
                };
                IResponse response = new Response(headers);

                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("DddesignkitTests"),
                    _exampleUri,
                    Substitute.For<ICredentialStore>(),
                    httpClient);

                var resp = await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative));
                Assert.NotNull(resp.HttpResponse.ApiInfo);
                Assert.Equal("user", resp.HttpResponse.ApiInfo.AcceptedOauthScopes.First());
            }

            [Fact]
            public async Task ThrowsAuthorizationExceptionExceptionForUnauthorizedResponse()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(HttpStatusCode.Unauthorized, null, new Dictionary<string, string>(), "application/json");
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("DddesignkitTests"),
                    _exampleUri,
                    Substitute.For<ICredentialStore>(),
                    httpClient);

                var exception = await AssertEx.Throws<AuthorizationException>(
                    async () => await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));
                Assert.NotNull(exception);
            }

            [Fact]
            public async Task ThrowsRateLimitExceededExceptionForForbidderResponse()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(
                    HttpStatusCode.Forbidden,
                    "{\"message\":\"API rate limit exceeded. " +
                    "See http://developer.dribbble.com/v1/#rate-limiting for details.\"}",
                    new Dictionary<string, string>(),
                    "application/json");
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("DddesignkitTests"),
                    _exampleUri,
                    Substitute.For<ICredentialStore>(),
                    httpClient);

                var exception = await AssertEx.Throws<RateLimitExceededException>(
                    async () => await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));

                Assert.Equal("API rate limit exceeded. See http://developer.dribbble.com/v1/#rate-limiting for details.",
                    exception.Message);
            }

            [Fact]
            public async Task ThrowsNotFoundExceptionForFileNotFoundResponse()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(
                    HttpStatusCode.NotFound,
                    "GONE BYE BYE!",
                    new Dictionary<string, string>(),
                    "application/json");

                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("DddesignkitTests"),
                    _exampleUri,
                    Substitute.For<ICredentialStore>(),
                    httpClient);

                var exception = await AssertEx.Throws<NotFoundException>(
                    async () => await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));

                Assert.Equal("GONE BYE BYE!", exception.Message);
            }

            [Fact]
            public async Task ThrowsForbiddenExceptionForUnknownForbiddenResponse()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(
                    HttpStatusCode.Forbidden,
                    "YOU SHALL NOT PASS!",
                    new Dictionary<string, string>(),
                    "application/json");
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("DddesignkitTests"),
                    _exampleUri,
                    Substitute.For<ICredentialStore>(),
                    httpClient);

                var exception = await AssertEx.Throws<ForbiddenException>(
                    async () => await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));

                Assert.Equal("YOU SHALL NOT PASS!", exception.Message);
            }
        }

        public class TheConstructor
        {
            [Fact]
            public void EnsuresAbsoluteBaseAddress()
            {
                Assert.Throws<ArgumentException>(() =>
                    new Connection(new ProductHeaderValue("TestRunner"), new Uri("foo", UriKind.Relative)));
                Assert.Throws<ArgumentException>(() =>
                    new Connection(new ProductHeaderValue("TestRunner"), new Uri("foo", UriKind.RelativeOrAbsolute)));
            }

            [Fact]
            public void EnsuresNonNullArguments()
            {
                // 1 arg
                Assert.Throws<ArgumentNullException>(() => new Connection(null));

                // 2 args
                Assert.Throws<ArgumentNullException>(() => new Connection(null, new Uri("https://example.com")));
                Assert.Throws<ArgumentNullException>(() => new Connection(new ProductHeaderValue("test"), (Uri)null));

                // 3 args
                Assert.Throws<ArgumentNullException>(() => new Connection(null,
                    new Uri("https://example.com"),
                    Substitute.For<ICredentialStore>()));
                Assert.Throws<ArgumentNullException>(() => new Connection(new ProductHeaderValue("foo"),
                    null,
                    Substitute.For<ICredentialStore>()));
                Assert.Throws<ArgumentNullException>(() => new Connection(new ProductHeaderValue("foo"),
                    new Uri("https://example.com"),
                    null));
            }

            [Fact]
            public void CreatesConnectionWithBaseAddress()
            {
                var connection = new Connection(new ProductHeaderValue("DddesignkitTests"), new Uri("https://dribbble.com/"));

                Assert.Equal(new Uri("https://dribbble.com/"), connection.BaseAddress);
                Assert.True(connection.UserAgent.StartsWith("DddesignkitTests ("));
            }
        }
    }
}
