using System;
using System.Collections.Generic;
using Xunit;

namespace Dddesignkit.Tests.Helpers
{
    public class UriExtensionsTests
    {
        public class TheApplyParametersMethod
        {
            [Fact]
            public void AppendsParametersAsQueryString()
            {
                var uri = new Uri("https://example.com");

                var uriWithParameters = uri.ApplyParameters(new Dictionary<string, string>
                {
                    {"foo", "foo val"},
                    {"bar", "barval"}
                });

                Assert.Equal(new Uri("https://example.com?foo=foo%20val&bar=barval"), uriWithParameters);
            }

            [Fact]
            public void ThrowsExceptionWhenNullValueProvided()
            {
                var uri = new Uri("https://example.com");

                var parameters = new Dictionary<string, string>
                {
                    {"foo", null },
                };

                Assert.Throws<ArgumentNullException>(() => uri.ApplyParameters(parameters));
            }

            [Fact]
            public void AppendsParametersAsQueryStringToRelativeUri()
            {
                var uri = new Uri("issues", UriKind.Relative);

                var uriWithParameters = uri.ApplyParameters(new Dictionary<string, string>
                {
                    {"foo", "fooval"},
                    {"bar", "barval"}
                });

                Assert.Equal(new Uri("issues?foo=fooval&bar=barval", UriKind.Relative), uriWithParameters);
            }

            [Fact]
            public void DoesNotChangeUrlWhenParametersEmpty()
            {
                var uri = new Uri("https://example.com");

                var uriWithEmptyParameters = uri.ApplyParameters(new Dictionary<string, string>());
                var uriWithNullParameters = uri.ApplyParameters(null);

                Assert.Equal(uri, uriWithEmptyParameters);
                Assert.Equal(uri, uriWithNullParameters);
            }

            [Fact]
            public void CombinesExistingParametersWithNewParameters()
            {
                var uri = new Uri("https://api.dribbble.com/v1/shots?list=animated&sort=comments&timeframe=week&page=2");

                var parameters = new Dictionary<string, string> { { "list", "playoffs" }, { "sort", "recent" } };

                var actual = uri.ApplyParameters(parameters);

                Assert.True(actual.Query.Contains("list=playoffs"));
                Assert.True(actual.Query.Contains("sort=recent"));
                Assert.True(actual.Query.Contains("timeframe=week"));
                Assert.True(actual.Query.Contains("page=2"));
            }

            [Fact]
            public void DoesNotChangePassedInDictionary()
            {
                var uri = new Uri("https://api.dribbble.com/v1/shots?list=animated&sort=comments&timeframe=week&page=2");

                var parameters = new Dictionary<string, string> { { "list", "playoffs" }, { "sort", "recent" } };

                uri.ApplyParameters(parameters);

                Assert.Equal(2, parameters.Count);
            }

            [Fact]
            public void EnsuresArgumentNotNull()
            {
                Uri uri = null;
                Assert.Throws<ArgumentNullException>(() => uri.ApplyParameters(new Dictionary<string, string>()));
            }
        }
    }
}
