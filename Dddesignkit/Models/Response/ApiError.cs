using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Dddesignkit
{
    /// <summary>
    /// Error payload from the API reposnse
    /// </summary>
#if !NETFX_CORE
    [Serializable]
#endif
    public class ApiError
    {
        public ApiError() { }

        public ApiError(string message)
        {
            Message = message;
        }

        public ApiError(string message, string documentationUrl, IReadOnlyList<ApiErrorDetail> errors)
        {
            Message = message;
            DocumentationUrl = documentationUrl;
            Errors = errors;
        }

        /// <summary>
        /// The error message
        /// </summary>
        [JsonProperty]
        public string Message { get; protected set; }

        /// <summary>
        /// URL to the documentation for this error.
        /// </summary>
        [JsonProperty]
        public string DocumentationUrl { get; protected set; }

        /// <summary>
        /// Additional details about the error
        /// </summary>
        [JsonProperty]
        public IReadOnlyList<ApiErrorDetail> Errors { get; protected set; }
    }
}
