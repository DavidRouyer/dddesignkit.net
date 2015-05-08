using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dddesignkit.Tests.Helpers
{
    public class StringExtensionsTests
    {
        public class TheIsBlankMethod
        {
            [InlineData(null, true)]
            [InlineData("", true)]
            [InlineData(" ", true)]
            [InlineData("nope", false)]
            [Theory]
            public void ProperlyDetectsBlankStrings(string data, bool expected)
            {
                Assert.Equal(expected, data.IsBlank());
            }
        }

        public class TheIsNotBlankMethod
        {
            [InlineData(null, false)]
            [InlineData("", false)]
            [InlineData(" ", false)]
            [InlineData("nope", true)]
            [Theory]
            public void ProperlyDetectsBlankStrings(string data, bool expected)
            {
                Assert.Equal(expected, data.IsNotBlank());
            }
        }

        public class TheExpandUriTemplateMethod
        {
            [Theory]
            [InlineData("https://host.com/path?name=other", "https://host.com/path?name=other")]
            [InlineData("https://host.com/path?name=example name.txt", "https://host.com/path{?name}")]
            [InlineData("https://host.com/path", "https://host.com/path{?other}")]
            public void ExpandsUriTemplates(string expected, string template)
            {
                Assert.Equal(expected, template.ExpandUriTemplate(new { name = "example name.txt" }).ToString());
            }
        }
    }
}
