using Microsoft.AspNetCore.Identity;

namespace MicroErp.Domain.Entity.Users;

public class Roles : IdentityRole
{
    public Roles() { }
    public ICollection<UserRoles> UserRoles { get; set; }
}
