using MicroErp.Domain.Entity.Users;
using MicroErp.Domain.Service.Abstract.Interfaces.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MicroErp.Domain.Service.Concretes.Users;

public class AccessManager : IAcessManager
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccessManager(
            UserManager<User> userManager,
            SignInManager<User> signInManager
        )
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<User> GetUserByUsername(string username)
    {
        return await _userManager.Users
              .FirstOrDefaultAsync(x => x.UserName == username);
    }

    public Task<SignInResult> ValidateCredentials(User user, string password)
    {
        return _signInManager.CheckPasswordSignInAsync(user, password, true);
    }
}
