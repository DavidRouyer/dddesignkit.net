using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// Class for retrieving Dribbble API URLs
    /// </summary>
    public class ApiUrls
    {
        static readonly Uri _currentUserBucketsUrl = new Uri("user/buckets", UriKind.Relative);
        static readonly Uri _currentUserFollowersUrl = new Uri("user/followers", UriKind.Relative);
        static readonly Uri _currentUserFollowingUrl = new Uri("user/following", UriKind.Relative);
        static readonly Uri _currentUserShotsUserFollowedUrl = new Uri("user/following/shots", UriKind.Relative);
        static readonly Uri _currentUserShotLikesUrl = new Uri("user/likes", UriKind.Relative);
        static readonly Uri _currentUserProjectsUrl = new Uri("user/projects", UriKind.Relative);
        static readonly Uri _currentUserShotsUrl = new Uri("user/shots", UriKind.Relative);
        static readonly Uri _currentUserTeamsUrl = new Uri("user/teams", UriKind.Relative);

        public static Uri Buckets(string username)
        {
            return "users/{0}/buckets".FormatUri(username);
        }

        public static Uri Buckets()
        {
            return _currentUserBucketsUrl;
        }

        public static Uri Followers(string username)
        {
            return "users/{0}/followers".FormatUri(username);
        }

        public static Uri Followers()
        {
            return _currentUserFollowersUrl;
        }

        public static Uri Following(string username)
        {
            return "users/{0}/following".FormatUri(username);
        }

        public static Uri Following()
        {
            return _currentUserFollowingUrl;
        }

        public static Uri ShotsUserFollowed()
        {
            return _currentUserShotsUserFollowedUrl;
        }

        public static Uri ShotLikes(string username)
        {
            return "users/{0}/likes".FormatUri(username);
        }

        public static Uri ShotLikes()
        {
            return _currentUserShotLikesUrl;
        }

        public static Uri Projects(string username)
        {
            return "users/{0}/projects".FormatUri(username);
        }

        public static Uri Projects()
        {
            return _currentUserProjectsUrl;
        }

        public static Uri Shots(string username)
        {
            return "users/{0}/shots".FormatUri(username);
        }

        public static Uri Shots()
        {
            return _currentUserShotsUrl;
        }

        public static Uri Teams(string username)
        {
            return "users/{0}/teams".FormatUri(username);
        }

        public static Uri Teams()
        {
            return _currentUserTeamsUrl;
        }

        /// <summary>
        /// Creates the relative <see cref="Uri"/> for checking is the current user is following another user
        /// </summary>
        /// <param name="following">name of the user followed</param>
        /// <returns>The <see cref="Uri"/> for checking if the current user follows the specified user.</returns>
        public static Uri IsFollowing(string following)
        {
            return "user/following/{0}".FormatUri(following);
        }

        /// <summary>
        /// Creates the relative <see cref="Uri"/> for checking if a user is following another user
        /// </summary>
        /// <param name="login">name of the user following</param>
        /// <param name="following">name of the user followed</param>
        /// <returns>The <see cref="Uri"/> for checking if the specified user follows another user</returns>
        public static Uri IsFollowing(string username, string following)
        {
            return "users/{0}/following/{1}".FormatUri(username, following);
        }

        public static Uri Follow(string follow)
        {
            return "users/{0}/follow".FormatUri(follow);
        }
    }
}
