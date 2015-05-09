using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Dddesignkit
{
    public class Shot
    {
        [JsonProperty]
        public int Id { get; private set; }

        [JsonProperty]
        public string Title { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty]
        public int Width { get; private set; }

        [JsonProperty]
        public int Height { get; private set; }

        [JsonProperty]
        public Image Images { get; private set; }

        [JsonProperty]
        public int ViewsCount { get; private set; }

        [JsonProperty]
        public int LikesCount { get; private set; }

        [JsonProperty]
        public int CommentsCount { get; private set; }

        [JsonProperty]
        public int AttachementsCount { get; private set; }

        [JsonProperty]
        public DateTimeOffset CreatedAt { get; private set; }

        [JsonProperty]
        public DateTimeOffset UpdatedAt { get; private set; }

        [JsonProperty]
        public string HtmlUrl { get; private set; }

        [JsonProperty]
        public string AttachmentsUrl { get; private set; }

        [JsonProperty]
        public string BucketsUrl { get; private set; }

        [JsonProperty]
        public string CommentsUrl { get; private set; }

        [JsonProperty]
        public string LikesUrl { get; private set; }

        [JsonProperty]
        public string ProjectsUrl { get; private set; }

        [JsonProperty]
        public string ReboundsUrl { get; private set; }

        [JsonProperty]
        public List<string> Tags { get; private set; }

        [JsonProperty]
        public User User { get; private set; }


    }

    public class Image {

        [JsonProperty]
        public string Hidpi { get; private set; }

        [JsonProperty]
        public string Normal { get; private set; }

        [JsonProperty]
        public string Teaser { get; private set; }
    }
}
