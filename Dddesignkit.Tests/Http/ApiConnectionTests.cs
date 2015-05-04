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
    }
}