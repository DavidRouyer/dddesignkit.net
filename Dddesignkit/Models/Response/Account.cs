using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit.Models.Response
{
    public abstract class Account
    {
        protected Account() { }

        [JsonProperty]
        public int Id { get; protected set; }

        [JsonProperty]
        public string Name { get; protected set; }

        [JsonProperty]
        public string Username { get; protected set; }

        [JsonProperty]
        public string HtmlUrl { get; protected set; }

        [JsonProperty]
        public string AvatarUrl { get; protected set; }

        [JsonProperty]
        public string Bio { get; protected set; }

        [JsonProperty]
        public string Location { get; protected set; }

        [JsonProperty]
        public Links Links { get; protected set; }

        [JsonProperty]
        public int BucketsCount { get; protected set; }

        [JsonProperty]
        public int CommentsReceivedCount { get; protected set; }

        [JsonProperty]
        public int FollowersCount { get; protected set; }

        [JsonProperty]
        public int FollowingCount { get; protected set; }

        [JsonProperty]
        public int LikesCount { get; protected set; }

        [JsonProperty]
        public int LikesReceivedCount { get; protected set; }

        [JsonProperty]
        public int ProjectsCount { get; protected set; }

        [JsonProperty]
        public int ReboundsReceivedCount { get; protected set; }

        [JsonProperty]
        public int ShotsCount { get; protected set; }

        [JsonProperty]
        public int TeamsCount { get; protected set; }

        [JsonProperty]
        public bool CanUploadShot { get; protected set; }

        [JsonProperty]
        public string Type { get; protected set; }

        [JsonProperty]
        public bool Pro { get; protected set; }

        [JsonProperty]
        public string BucketsUrl { get; protected set; }

        [JsonProperty]
        public string FollowersUrl { get; protected set; }

        [JsonProperty]
        public string FollowingUrl { get; protected set; }

        [JsonProperty]
        public string LikesUrl { get; protected set; }

        [JsonProperty]
        public string ShotsUrl { get; protected set; }

        [JsonProperty]
        public string TeamsUrl { get; protected set; }

        [JsonProperty]
        public DateTimeOffset CreatedAt { get; protected set; }

        [JsonProperty]
        public DateTimeOffset UpdatedAt { get; protected set; }
    }

    public class Links
    {
        protected Links() {}

        [JsonProperty]
        public string Web { get; private set; }

        [JsonProperty]
        public string Twitter { get; private set; }
    }
}
