using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit
{
    public class Team
    {
        [JsonProperty]
        public int Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string Username { get; private set; }

        [JsonProperty]
        public string HtmlUrl { get; private set; }

        [JsonProperty]
        public string AvatarUrl { get; private set; }

        [JsonProperty]
        public string Bio { get; private set; }

        [JsonProperty]
        public string Location { get; private set; }

        [JsonProperty]
        public Links Links { get; private set; }

        [JsonProperty]
        public int BucketsCount { get; private set; }

        [JsonProperty]
        public int CommentsReceivedCount { get; private set; }

        [JsonProperty]
        public int FollowersCount { get; private set; }

        [JsonProperty]
        public int FollowingsCount { get; private set; }

        [JsonProperty]
        public int LikesCount { get; private set; }

        [JsonProperty]
        public int LikesReceivedCount { get; private set; }

        [JsonProperty]
        public int MembersCount { get; private set; }

        [JsonProperty]
        public int ProjectsCount { get; private set; }

        [JsonProperty]
        public int ReboundsReceivedCount { get; private set; }

        [JsonProperty]
        public int ShotsCount { get; private set; }

        [JsonProperty]
        public bool CanUploadShot { get; private set; }

        [JsonProperty]
        public string Type { get; private set; }

        [JsonProperty]
        public bool Pro { get; private set; }

        [JsonProperty]
        public string BucketsUrl { get; private set; }

        [JsonProperty]
        public string FollowersUrl { get; private set; }

        [JsonProperty]
        public string FollowingUrl { get; private set; }

        [JsonProperty]
        public string LikesUrl { get; private set; }

        [JsonProperty]
        public string MembersUrl { get; private set; }

        [JsonProperty]
        public string ShotsUrl { get; private set; }

        [JsonProperty]
        public string TeamShotsUrl { get; private set; }

        [JsonProperty]
        public DateTimeOffset CreatedAt { get; protected set; }

        [JsonProperty]
        public DateTimeOffset UpdatedAt { get; protected set; }
    }
}
