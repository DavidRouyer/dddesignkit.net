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
        public static Uri Buckets(string username)
        {
            return "users/{0}/buckets".FormatUri(username);
        }
    }
}
