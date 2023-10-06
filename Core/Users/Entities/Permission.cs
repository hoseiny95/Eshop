
namespace App.Domain.Core.Users.Entities;

public class Permission
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Role> Roles { get; set; }
}
