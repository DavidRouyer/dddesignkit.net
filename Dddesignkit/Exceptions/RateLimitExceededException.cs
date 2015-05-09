using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dddesignkit
{
    /// <summary>
    /// Exception thrown when Dribbble API Rate limits are exceeded.
    /// </summary>
    /// <summary>
    /// <para>
    /// You can make up to 60 requests per minute, with a hard limit of 10,000 per day.
    /// For requests using OAuth, the rate limit is for each application and user combination.
    /// For unauthenticated requests, the rate limit is for all requests using the application token.
    /// </para>
    /// <para>See http://developer.dribbble.com/v1/#rate-limiting for more details.</para>
    /// </summary>
#if !NETFX_CORE
    [Serializable]
#endif
    public class RateLimitExceededException : ForbiddenException
    {
        readonly RateLimit _rateLimit;

        /// <summary>
        /// Constructs an instance of RateLimitExceededException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        public RateLimitExceededException(IResponse response)
            : this(response, null)
        {
        }

        /// <summary>
        /// Constructs an instance of RateLimitExceededException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        /// <param name="innerException">The inner exception</param>
        public RateLimitExceededException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Ensure.ArgumentNotNull(response, "response");

            _rateLimit = response.ApiInfo.RateLimit;
        }

        /// <summary>
        /// The maximum number of requests that the consumer is permitted to make per hour.
        /// </summary>
        public int Limit
        {
            get { return _rateLimit.Limit; }
        }

        /// <summary>
        /// The number of requests remaining in the current rate limit window.
        /// </summary>
        public int Remaining
        {
            get { return _rateLimit.Remaining; }
        }

        /// <summary>
        /// The date and time at which the current rate limit window resets
        /// </summary>
        public DateTimeOffset Reset
        {
            get { return _rateLimit.Reset; }
        }

        // TODO: Might be nice to have this provide a more detailed message such as what the limit is,
        // how many are remaining, and when it will reset. I'm too lazy to do it now.
        public override string Message
        {
            get { return ApiErrorMessageSafe ?? "API Rate Limit exceeded"; }
        }

#if !NETFX_CORE
        /// <summary>
        /// Constructs an instance of RateLimitExceededException
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the
        /// serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains
        /// contextual information about the source or destination.
        /// </param>
        protected RateLimitExceededException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _rateLimit = info.GetValue("RateLimit", typeof(RateLimit)) as RateLimit
                         ?? new RateLimit(new Dictionary<string, string>());
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("RateLimit", _rateLimit);
        }
#endif
    }
}
