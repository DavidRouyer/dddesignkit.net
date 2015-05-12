using Newtonsoft.Json;
using System;

namespace Dddesignkit
{
    public class Followers
    {
        [JsonProperty]
        public int Id { get; private set; }

        [JsonProperty]
        public DateTimeOffset CreatedAt { get; private set; }

        [JsonProperty]
        public User Follower { get; private set; }
    }
}
