using Newtonsoft.Json;

namespace Dddesignkit
{
    public class Links
    {
        protected Links() { }

        [JsonProperty]
        public string Web { get; private set; }

        [JsonProperty]
        public string Twitter { get; private set; }
    }
}
