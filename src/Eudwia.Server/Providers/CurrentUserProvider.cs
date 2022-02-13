using System.Security.Claims;

namespace Eudwia.Server.Providers;

public interface ICurrentUserProvider
{
    string Username { get; }
}

public class CurrentUserProvider : ICurrentUserProvider
{
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public string Username => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name) ?? string.Empty;
}