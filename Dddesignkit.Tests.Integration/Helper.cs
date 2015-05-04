using System;
using System.Diagnostics;

namespace Dddesignkit.Tests.Integration
{
    public static class Helper
    {
        static readonly Lazy<Credentials> _credentialsThunk = new Lazy<Credentials>(() =>
        {
            var dribbbleUsername = Environment.GetEnvironmentVariable("DDDESIGNKIT_DRIBBBLEUSERNAME");
            UserName = dribbbleUsername;

            var dribbbleToken = Environment.GetEnvironmentVariable("DDDESIGNKIT_OAUTHTOKEN");

            if (dribbbleToken != null)
                return new Credentials(dribbbleToken);

            var dribbblePassword = Environment.GetEnvironmentVariable("DDDESIGNKIT_DRIBBBLEPASSWORD");

            if (dribbbleUsername == null || dribbblePassword == null)
                return null;

            return new Credentials(dribbbleUsername, dribbblePassword);
        });

        static readonly Lazy<Credentials> _oauthApplicationCredentials = new Lazy<Credentials>(() =>
        {
            var applicationClientId = ClientId;
            var applicationClientSecret = ClientSecret;

            if (applicationClientId == null || applicationClientSecret == null)
                return null;

            return new Credentials(applicationClientId, applicationClientSecret);
        });

        static Helper()
        {
            // Force reading of environment variables.
            // This wasn't happening if UserName/Organization were 
            // retrieved before Credentials.
            Debug.WriteIf(Credentials == null, "No credentials specified.");
        }

        public static string UserName { get; private set; }
        public static string Organization { get; private set; }

        public static Credentials Credentials { get { return _credentialsThunk.Value; } }

        public static Credentials ApplicationCredentials { get { return _oauthApplicationCredentials.Value; } }

        public static string ClientId
        {
            get { return Environment.GetEnvironmentVariable("DDDESIGNKIT_CLIENTID"); }
        }

        public static string ClientSecret
        {
            get { return Environment.GetEnvironmentVariable("DDDESIGNKIT_CLIENTSECRET"); }
        }

        public static string MakeNameWithTimestamp(string name)
        {
            return string.Concat(name, "-", DateTime.UtcNow.ToString("yyyyMMddhhmmssfff"));
        }

        public static IDribbbleClient GetAuthenticatedClient()
        {
            return new DribbbleClient(new ProductHeaderValue("DddesignkitTests"))
            {
                Credentials = Credentials
            };
        }

        public static DribbbleClient GetAuthenticatedApplicationClient()
        {
            return new DribbbleClient(new ProductHeaderValue("DddesignkitTests"))
            {
                Credentials = ApplicationCredentials
            };
        }

        public static IDribbbleClient GetAnonymousClient()
        {
            return new DribbbleClient(new ProductHeaderValue("DddesignkitTests"));
        }

        public static IDribbbleClient GetBadCredentialsClient()
        {
            return new DribbbleClient(new ProductHeaderValue("DddesignkitTests"))
            {
                Credentials = new Credentials(Credentials.Login, "bad-password")
            };
        }
    }
}
