using MicroErp.Domain.Entity.Users;
using Microsoft.AspNetCore.Identity;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Users;

public interface IAcessManager
{
    Task<User> GetUserByUsername(string username);
    Task<SignInResult> ValidateCredentials(User user, string password);
}
