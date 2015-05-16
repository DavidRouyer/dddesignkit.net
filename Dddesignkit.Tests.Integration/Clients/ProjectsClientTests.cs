using Dddesignkit.Tests.Integration;
using System.Threading.Tasks;
using Xunit;

public class ProjectsClientTests
{
    public class TheGetMethod
    {
        [IntegrationTest]
        public async Task ReturnsSpecifiedUser()
        {
            var dribbble = Helper.GetAuthenticatedClient();

            var project = await dribbble.Projects.Get(3);

            Assert.Equal(3, project.Id);
        }
    }
}
