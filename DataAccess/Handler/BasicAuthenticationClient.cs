using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;

namespace Volunteer.DataAccess.Handler
{
    public class BasicAuthenticationClient : IIdentity
    {
        public string? AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Name { get; set; }
    }

    public class BasicAuthenticationDefaults
    {
        public const string AuthenticationScheme = "Basic";
    }

    public class BasicAuthorizationAttribute : AuthorizeAttribute
    {
        public BasicAuthorizationAttribute()
        {
            AuthenticationSchemes = BasicAuthenticationDefaults.AuthenticationScheme;
        }
    }
}