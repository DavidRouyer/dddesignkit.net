using Dddesignkit.Internal;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dddesignkit.Tests
{
    public class DribbbleClientTests
    {
        public class TheConstructor
        {
            [Fact]
            public void CreatesAnonymousClientByDefault()
            {
                var client = new DribbbleClient(new ProductHeaderValue("DddesignkitTests", "1.0"));

                Assert.Equal(AuthenticationType.Anonymous, client.Credentials.AuthenticationType);
            }

            [Fact]
            public void CanCreateBasicAuthClient()
            {
                var client = new DribbbleClient(new ProductHeaderValue("DddesignkitTests", "1.0"))
                {
                    Credentials = new Credentials("tclem", "pwd")
                };

                Assert.Equal(AuthenticationType.Basic, client.Credentials.AuthenticationType);
            }

            [Fact]
            public void CanCreateOauthClient()
            {
                var client = new DribbbleClient(new ProductHeaderValue("DddesignkitTests"))
                {
                    Credentials = new Credentials("token")
                };

                Assert.Equal(AuthenticationType.Oauth, client.Credentials.AuthenticationType);
            }
        }

        public class TheBaseAddressProperty
        {
            [Fact]
            public void IsSetToDribbbleApiV1()
            {
                var client = new DribbbleClient(new ProductHeaderValue("DddesignkitTests", "1.0"));

                Assert.Equal(new Uri("https://api.dribbble.com/v1/"), client.BaseAddress);
            }
        }

        public class TheCredentialsProperty
        {
            [Fact]
            public void DefaultsToAnonymous()
            {
                var client = new DribbbleClient(new ProductHeaderValue("DddesignkitTests", "1.0"));
                Assert.Same(Credentials.Anonymous, client.Credentials);
            }

            [Fact]
            public void WhenSetCreatesInMemoryStoreThatReturnsSpecifiedCredentials()
            {
                var credentials = new Credentials("Peter", "Griffin");
                var client = new DribbbleClient(new ProductHeaderValue("DddesignkitTests"),
                    Substitute.For<ICredentialStore>())
                {
                    Credentials = credentials
                };

                Assert.IsType<InMemoryCredentialStore>(client.Connection.CredentialStore);
                Assert.Same(credentials, client.Credentials);
            }

            [Fact]
            public void IsRetrievedFromCredentialStore()
            {
                var credentialStore = Substitute.For<ICredentialStore>();
                credentialStore.GetCredentials().Returns(Task.Factory.StartNew(() => new Credentials("foo", "bar")));
                var client = new DribbbleClient(new ProductHeaderValue("DddesignkitTests"), credentialStore);

                Assert.Equal("foo", client.Credentials.Login);
                Assert.Equal("bar", client.Credentials.Password);
            }
        }
    }
}
