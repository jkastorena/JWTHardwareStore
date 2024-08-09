using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JWTHardwareStore;

public class UserRole
{

    [Key]
    public int UserRoleId { get; set; }
    [ForeignKey("Role")]
    public Guid UserId { get; set; } 
    [ForeignKey("User")]
    public Guid RoleId { get; set; }

    public Role Role { get; set; }
    public User User { get; set; }
}

public class UserRoleRequest
{
    public string? Email { get; set; }
    public string? RoleName { get; set;}
}
