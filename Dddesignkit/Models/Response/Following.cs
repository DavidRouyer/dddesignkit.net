using Newtonsoft.Json;
using System;

namespace Dddesignkit
{
    public class Following
    {
        [JsonProperty]
        public int Id { get; private set; }

        [JsonProperty]
        public DateTimeOffset CreatedAt { get; private set; }

        [JsonProperty]
        public User Followee { get; private set; }
    }
}
