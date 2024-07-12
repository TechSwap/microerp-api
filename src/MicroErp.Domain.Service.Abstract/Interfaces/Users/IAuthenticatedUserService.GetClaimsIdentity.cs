using System.Security.Claims;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Users;

public interface IAuthenticatedUserService
{
    IEnumerable<Claim> GetClaimsIdentity();
}