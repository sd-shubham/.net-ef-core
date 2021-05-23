using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace CoreAPIAndEfCore.Services
{
    public class ServiceContext : IServiceContext
    {
        private readonly IHttpContextAccessor _httpContext;
        public ServiceContext(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;

        }
        public int UserId => int.Parse(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public string UserRole => _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Role);
    }
}