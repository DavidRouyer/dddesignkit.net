using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using System.Net.Http;

namespace Dddesignkit.Internal
{
    public class JsonHttpPipeline
    {
        private const string v1ApiVersion = "application/json; charset=utf-8";

        public JsonHttpPipeline()
        {
        }

        public void SerializeRequest(IRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            if (!request.Headers.ContainsKey("Accept"))
            {

                request.Headers["Accept"] = v1ApiVersion;
            }

            if (request.Method == HttpMethod.Get || request.Body == null) return;
            if (request.Body is string || request.Body is Stream || request.Body is HttpContent) return;

            request.Body = JsonConvert.SerializeObject(request.Body);
        }

        public IApiResponse<T> DeserializeResponse<T>(IResponse response)
        {
            Ensure.ArgumentNotNull(response, "response");

            if (response.ContentType != null && response.ContentType.Equals("application/json", StringComparison.Ordinal))
            {
                var body = response.Body as string;
                // simple json does not support the root node being empty. Will submit a pr but in the mean time....
                if (!String.IsNullOrEmpty(body) && body != "{}")
                {
                    var typeIsDictionary = typeof(IDictionary).IsAssignableFrom(typeof(T));
                    var typeIsEnumerable = typeof(IEnumerable).IsAssignableFrom(typeof(T));
                    var responseIsArray = body.StartsWith("{", StringComparison.Ordinal);

                    // If we're expecting an array, but we get a single object, just wrap it.
                    // This supports an api that dynamically changes the return type based on the content.
                    if (!typeIsDictionary && typeIsEnumerable && responseIsArray)
                    {
                        body = "[" + body + "]";
                    }
                    var json = JsonConvert.DeserializeObject<T>(body, new JsonSerializerSettings { ContractResolver = new JsonLowerCaseUnderscoreContractResolver() });
                    return new ApiResponse<T>(response, json);
                }
            }
            return new ApiResponse<T>(response);
        }
    }
}
