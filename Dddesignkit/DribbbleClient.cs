using Dddesignkit.Clients;
using System;

namespace Dddesignkit
{
    /// <summary>
    /// A Client for the Dribbble API v1. You can read more about the api here: http://developer.dribbble.com.
    /// </summary>
    public class DribbbleClient : IDribbbleClient
    {
        /// <summary>
        /// The base address for the Dribbble API
        /// </summary>
        public static readonly Uri DribbbleApiUrl = new Uri("https://api.dribbble.com/v1/");

        /// <summary>
        /// Create a new instance of the Dribbble API v1 client pointing to 
        /// https://api.dribbble.com/
        /// </summary>
        /// <param name="productInformation">
        /// The name (and optionally version) of the product using this library. This is sent to the server as part of
        /// the user agent for analytics purposes.
        /// </param>
        public DribbbleClient(ProductHeaderValue productInformation)
            : this(new Connection(productInformation))
        {
        }

        /// <summary>
        /// Create a new instance of the Dribbble API v1 client pointing to 
        /// https://api.dribbble.com/v1/
        /// </summary>
        /// <param name="productInformation">
        /// The name (and optionally version) of the product using this library. This is sent to the server as part of
        /// the user agent for analytics purposes.
        /// </param>
        /// <param name="credentialStore">Provides credentials to the client when making requests</param>
        public DribbbleClient(ProductHeaderValue productInformation, ICredentialStore credentialStore)
            : this(new Connection(productInformation, credentialStore))
        {
        }

        public DribbbleClient(IConnection connection)
        {
            Ensure.ArgumentNotNull(connection, "connection");

            Connection = connection;
            var apiConnection = new ApiConnection(connection);
            User = new UsersClient(apiConnection);
        }

        /// <summary>
        /// Convenience property for getting and setting credentials.
        /// </summary>
        /// <remarks>
        /// You can use this property if you only have a single hard-coded credential. Otherwise, pass in an 
        /// <see cref="ICredentialStore"/> to the constructor. 
        /// Setting this property will change the <see cref="ICredentialStore"/> to use 
        /// the default <see cref="InMemoryCredentialStore"/> with just these credentials.
        /// </remarks>
        public Credentials Credentials
        {
            get { return Connection.Credentials; }
            // Note this is for convenience. We probably shouldn't allow this to be mutable.
            set
            {
                Ensure.ArgumentNotNull(value, "value");
                Connection.Credentials = value;
            }
        }

        /// <summary>
        /// The base address of the Dribbble API. This defaults to https://api.dribbble.com.
        /// </summary>
        public Uri BaseAddress
        {
            get { return Connection.BaseAddress; }
        }

        /// <summary>
        /// Provides a client connection to make rest requests to HTTP endpoints.
        /// </summary>
        public IConnection Connection { get; private set; }

        /// <summary>
        /// Access Dribbble's Users API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: https://developer.dribbble.com/v1/users/
        /// </remarks>
        public IUsersClient User { get; private set; }
    }
}
