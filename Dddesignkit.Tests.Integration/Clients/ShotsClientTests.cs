using Dddesignkit.Tests.Integration;
using System.Threading.Tasks;
using Xunit;

public class ShotsClientTests
{
    public class GetAllMethod
    {
        [IntegrationTest(Skip = "Takes too long to run.")]
        public async Task ReturnsAllShots()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var shots = await dribbble.Shots.GetAll();

            Assert.True(shots.Count > 80);
        }
    }

    public class GetMethod
    {
        [IntegrationTest]
        public async Task ReturnsSpecifiedShot()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var shot = await dribbble.Shots.Get(42);

            Assert.Equal(42, shot.Id);
        }
    }
}