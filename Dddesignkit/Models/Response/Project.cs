using Newtonsoft.Json;
using System;

namespace Dddesignkit
{
    public class Project
    {
        [JsonProperty]
        public int Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty]
        public int ShotsCount { get; private set; }

        [JsonProperty]
        public DateTimeOffset CreatedAt { get; private set; }

        [JsonProperty]
        public DateTimeOffset UpdatedAt { get; private set; }
    }
}
