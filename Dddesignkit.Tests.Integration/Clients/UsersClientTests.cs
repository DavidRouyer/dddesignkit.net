using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dddesignkit.Tests.Integration.Clients
{
    public class UsersClientTests
    {
        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task ReturnsSpecifiedUser()
            {
                var dribbble = Helper.GetAuthenticatedClient();

                var user = await dribbble.User.Get("simplebits");

                Assert.Equal(1, user.Id);
            }
        }
    }
}
