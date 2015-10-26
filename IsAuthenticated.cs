using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace SS
{
    [Route("/IsAuthenticated")]
    public class IsAuthenticated
    {
    }

    public class IsAuthenticatedResponse
    {
        public bool IsAuthenticated { get; set; }
    }

    public class IsAuthenticatedService : Service
    {
        public object Any(IsAuthenticated request)
        {
            var isAuthenticated = HttpContext.Current.User.Identity.IsAuthenticated;

            return new IsAuthenticatedResponse
            {
                IsAuthenticated = isAuthenticated
            };
        }
    }
}