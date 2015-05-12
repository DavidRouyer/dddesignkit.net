using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit
{
    public class Like
    {
        [JsonProperty]
        public int Id { get; private set; }

        [JsonProperty]
        public DateTimeOffset CreatedAt { get; private set; }

        [JsonProperty]
        public Shot Shot { get; private set; }
    }
}
