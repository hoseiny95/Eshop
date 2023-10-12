
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Users.Entities;

public class UserRole : IdentityUserRole<int>
{
    public ApplicationUser User { get; set; }
    public Role Role { get; set; }
}
