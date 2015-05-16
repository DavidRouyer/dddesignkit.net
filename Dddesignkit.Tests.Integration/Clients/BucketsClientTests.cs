using Dddesignkit.Tests.Integration;
using System.Threading.Tasks;
using Xunit;

public class BucketsClientTests
{
    public class TheGetMethod
    {
        [IntegrationTest]
        public async Task ReturnsSpecifiedUser()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var bucket = await dribbble.Buckets.Get(2754);

            Assert.Equal(2754, bucket.Id);
        }
    }
}
