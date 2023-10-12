
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Users.Entities;
public class Role : IdentityRole<int>
{
    public List<Permission> Permissions { get; set; }
   // public List<ApplicationUser> Users { get; set; }

}
