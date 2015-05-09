using Dddesignkit.Internal;
using Xunit;

namespace Dddesignkit.Tests.Http
{
    public class ResponseTests
    {
        public class TheConstructor
        {
            [Fact]
            public void InitializesAllRequiredProperties()
            {
                var r = new Response();

                Assert.NotNull(r.Headers);
            }
        }
    }
}
