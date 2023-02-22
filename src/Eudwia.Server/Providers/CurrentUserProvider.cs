using System.Security.Claims;
    using Eudwia.Shared.Extensions;

namespace Eudwia.Server.Providers;

public interface ICurrentUserProvider
{
    string Username { get; }
    string FirstName { get; }
    string LastName { get; }
    string FullName { get; }
    Guid TenantId { get; }
}

public class CurrentUserProvider : ICurrentUserProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string Username => _httpContextAccessor.HttpContext?.User.Email() ?? string.Empty;
    public string FirstName => _httpContextAccessor.HttpContext?.User.FirstName() ?? string.Empty;
    public string LastName => _httpContextAccessor.HttpContext?.User.LastName() ?? string.Empty;
    public string FullName => $"{_httpContextAccessor.HttpContext?.User.FirstName() ?? string.Empty} {_httpContextAccessor.HttpContext?.User.LastName() ?? string.Empty}";
    public Guid TenantId => _httpContextAccessor.HttpContext?.User.Tenant() ?? Guid.Empty;
}