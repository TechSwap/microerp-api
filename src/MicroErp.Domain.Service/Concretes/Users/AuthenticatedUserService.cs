using System.Security.Claims;
using MicroErp.Application.Util;
using MicroErp.Domain.Service.Abstract.Interfaces.Users;
using Microsoft.AspNetCore.Http;

namespace MicroErp.Domain.Service.Concretes.Users;

public class AuthenticatedUserService: IAuthenticatedUserService
{
    private readonly IHttpContextAccessor _accessor;

    public AuthenticatedUserService(IHttpContextAccessor accessor) => _accessor = accessor;

    public string UserId => CriptografiaHelper.DecryptQueryString(GetClaimsIdentity().FirstOrDefault(a => a.Type == "Cod")?.Value);
    public string Email => GetClaimsIdentity().FirstOrDefault(a => a.Type == "Email")?.Value;
    public string Nome => GetClaimsIdentity().FirstOrDefault(a => a.Type == "Nome")?.Value;
    
    public IEnumerable<Claim> GetClaimsIdentity()
    {
        return _accessor.HttpContext.User.Claims;
    }
}