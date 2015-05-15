using NSubstitute;
using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Dddesignkit.Tests.Helpers;
using Dddesignkit.Internal;

namespace Dddesignkit.Tests.Http
{
    public class ApiConnectionTests
    {
        public class TheGetMethod
        {
            [Fact]
            public async Task MakesGetRequestForItem()
            {
                var getUri = new Uri("anything", UriKind.Relative);
                IApiResponse<object> response = new ApiResponse<object>(new Response());
                var connection = Substitute.For<IConnection>();
                connection.Get<object>(Args.Uri, null, null).Returns(Task.FromResult(response));
                var apiConnection = new ApiConnection(connection);

                var data = await apiConnection.Get<object>(getUri);

                Assert.Same(response.Body, data);
                connection.Received().GetResponse<object>(getUri);
            }

            [Fact]
            public async Task MakesGetRequestForItemWithAcceptsOverride()
            {
                var getUri = new Uri("anything", UriKind.Relative);
                const string accepts = "custom/accepts";
                IApiResponse<object> response = new ApiResponse<object>(new Response());
                var connection = Substitute.For<IConnection>();
                connection.Get<object>(Args.Uri, null, Args.String).Returns(Task.FromResult(response));
                var apiConnection = new ApiConnection(connection);

                var data = await apiConnection.Get<object>(getUri, null, accepts);

                Assert.Same(response.Body, data);
                connection.Received().Get<object>(getUri, null, accepts);
            }

            [Fact]
            public async Task EnsuresArgumentNotNull()
            {
                var getUri = new Uri("anything", UriKind.Relative);
                var client = new ApiConnection(Substitute.For<IConnection>());
                await AssertEx.Throws<ArgumentNullException>(async () => await client.Get<object>(null));
                await AssertEx.Throws<ArgumentNullException>(async () => await client.Get<object>(getUri, new Dictionary<string, string>(), null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task MakesGetRequestForAllItems()
            {
                var getAllUri = new Uri("anything", UriKind.Relative);
                IApiResponse<List<object>> response = new ApiResponse<List<object>>(
                    new Response(),
                    new List<object> { new object(), new object() });
                var connection = Substitute.For<IConnection>();
                connection.Get<List<object>>(Args.Uri, null, null).Returns(Task.FromResult(response));
                var apiConnection = new ApiConnection(connection);

                var data = await apiConnection.GetAll<object>(getAllUri);

                Assert.Equal(2, data.Count);
                connection.Received().Get<List<object>>(getAllUri, null, null);
            }

            [Fact]
            public async Task EnsuresArgumentNotNull()
            {
                var client = new ApiConnection(Substitute.For<IConnection>());

                // One argument
                await AssertEx.Throws<ArgumentNullException>(async () => await client.GetAll<object>(null));

                // Two argument
                await AssertEx.Throws<ArgumentNullException>(async () =>
                    await client.GetAll<object>(null, new Dictionary<string, string>()));

                // Three arguments
                await AssertEx.Throws<ArgumentNullException>(async () =>
                    await client.GetAll<object>(null, new Dictionary<string, string>(), "accepts"));
            }
        }

        public class ThePutMethod
        {
            [Fact]
            public async Task MakesPutRequestWithSuppliedData()
            {
                var putUri = new Uri("anything", UriKind.Relative);
                var sentData = new object();
                IApiResponse<object> response = new ApiResponse<object>(new Response());
                var connection = Substitute.For<IConnection>();
                connection.Put<object>(Args.Uri, Args.Object).Returns(Task.FromResult(response));
                var apiConnection = new ApiConnection(connection);

                var data = await apiConnection.Put<object>(putUri, sentData);

                Assert.Same(data, response.Body);
                connection.Received().Put<object>(putUri, sentData);
            }

            [Fact]
            public async Task EnsuresArgumentsNotNull()
            {
                var putUri = new Uri("", UriKind.Relative);
                var connection = new ApiConnection(Substitute.For<IConnection>());

                // 2 parameter overload
                await AssertEx.Throws<ArgumentNullException>(async () =>
                    await connection.Put<object>(null, new object()));
                await AssertEx.Throws<ArgumentNullException>(async () =>
                    await connection.Put<object>(putUri, null));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public async Task MakesDeleteRequest()
            {
                var deleteUri = new Uri("anything", UriKind.Relative);
                HttpStatusCode statusCode = HttpStatusCode.NoContent;
                var connection = Substitute.For<IConnection>();
                connection.Delete(Args.Uri).Returns(Task.FromResult(statusCode));
                var apiConnection = new ApiConnection(connection);

                await apiConnection.Delete(deleteUri);

                connection.Received().Delete(deleteUri);
            }

            [Fact]
            public async Task EnsuresArgumentNotNull()
            {
                var connection = new ApiConnection(Substitute.For<IConnection>());
                await AssertEx.Throws<ArgumentNullException>(async () => await connection.Delete(null));
            }
        }

        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new ApiConnection(null));
            }
        }
    }
}