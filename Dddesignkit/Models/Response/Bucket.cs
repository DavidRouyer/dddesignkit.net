using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit
{
    public class Bucket
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

        [JsonProperty]
        public User User { get; private set; }
    }
}
