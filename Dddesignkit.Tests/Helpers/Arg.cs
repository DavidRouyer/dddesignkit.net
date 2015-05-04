using Dddesignkit.Internal;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Dddesignkit.Tests.Helpers
{
    internal class Args
    {
        public static Uri Uri
        {
            get { return Arg.Any<Uri>(); }
        }

        public static IRequest Request
        {
            get { return Arg.Any<IRequest>(); }
        }

        public static object Object
        {
            get { return Arg.Any<object>(); }
        }

        public static string String
        {
            get { return Arg.Any<string>(); }
        }

        public static Dictionary<string, string> EmptyDictionary
        {
            get { return Arg.Is<Dictionary<string, string>>(d => d.Count == 0); }
        }

        public static CancellationToken CancellationToken
        {
            get { return Arg.Any<CancellationToken>(); }
        }
    }
}
