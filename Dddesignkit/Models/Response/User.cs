using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit.Models.Response
{
    /// <summary>
    /// Represents a user on Dribbble.
    /// </summary>
    public class User : Account
    {
        public User()
        {
        }

        public User(int id, string name, string username, string htmlUrl, string avatarUrl, string bio, string location, Links links, int bucketsCount,
            int commentsReceivedCount, int followersCount, int followingCount, int likesCount, int likesReceivedCount, int projectsCount,
            int reboundsReceivedCount, int shotsCount, int teamsCount, bool canUploadShot, string type, bool pro, string bucketsUrl,
            string followersUrl, string followingUrl, string likesUrl, string shotsUrl, string teamsUrl, DateTimeOffset createdAt, DateTimeOffset updatedAt)
        {
            Id = id;
            Name = name;
            Username = username;
            HtmlUrl = htmlUrl;
            AvatarUrl = avatarUrl;
            Bio = bio;
            Location = location;
            Links = links;
            BucketsCount = bucketsCount;
            CommentsReceivedCount = commentsReceivedCount;
            FollowersCount = followersCount;
            FollowingCount = followingCount;
            LikesCount = likesCount;
            LikesReceivedCount = likesReceivedCount;
            ProjectsCount = projectsCount;
            ReboundsReceivedCount = reboundsReceivedCount;
            ShotsCount = shotsCount;
            TeamsCount = teamsCount;
            CanUploadShot = canUploadShot;
            Type = type;
            Pro = pro;
            BucketsUrl = bucketsUrl;
            FollowersUrl = followersUrl;
            FollowingUrl = followingUrl;
            LikesUrl = likesUrl;
            ShotsUrl = shotsUrl;
            TeamsUrl = teamsUrl;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        internal string DebuggerDisplay
        {
            get
            {
                return String.Format(CultureInfo.InvariantCulture,
                    "User: Id: {0} Login: {1}", Id, Username);
            }
        }
    }
}
