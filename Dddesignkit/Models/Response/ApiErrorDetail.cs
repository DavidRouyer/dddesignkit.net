using Newtonsoft.Json;
using System;

namespace Dddesignkit.Models.Response
{
#if !NETFX_CORE
    [Serializable]
#endif
    public class ApiErrorDetail
    {
        public ApiErrorDetail() { }

        public ApiErrorDetail(string message, string code, string field, string resource)
        {
            Message = message;
            Code = code;
            Field = field;
            Resource = resource;
        }

        [JsonProperty]
        public string Message { get; protected set; }

        [JsonProperty]
        public string Code { get; protected set; }

        [JsonProperty]
        public string Field { get; protected set; }

        [JsonProperty]
        public string Resource { get; protected set; }
    }
}
