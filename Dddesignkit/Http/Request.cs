﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit.Internal
{
    public class Request : IRequest
    {
        public Request()
        {
            Headers = new Dictionary<string, string>();
            Parameters = new Dictionary<string, string>();
            Timeout = TimeSpan.FromSeconds(100);
        }

        public object Body { get; set; }

        public Dictionary<string, string> Headers { get; private set; }

        public HttpMethod Method { get; set; }

        public Dictionary<string, string> Parameters { get; private set; }

        public Uri BaseAddress { get; set; }

        public Uri Endpoint { get; set; }

        public TimeSpan Timeout { get; set; }

        public string ContentType { get; set; }
    }
}
