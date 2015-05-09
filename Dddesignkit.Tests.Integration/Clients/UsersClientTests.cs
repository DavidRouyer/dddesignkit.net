using Dddesignkit.Tests.Integration;
using System.Threading.Tasks;
using Xunit;

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

    public class TheCurrentMethod
    {
        [IntegrationTest]
        public async Task ReturnsCurrentUser()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var user = await dribbble.User.Current();

            Assert.Equal(Helper.UserName, user.Username);

        }
    }

    public class TheGetAllBucketsMethod
    {
        [IntegrationTest]
        public async Task ReturnsAllUserBuckets()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var buckets = await dribbble.User.GetAllBuckets("simplebits");

            Assert.True(buckets.Count >= 10);
        }
    }
}