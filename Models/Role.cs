using System.ComponentModel.DataAnnotations;
namespace JWTHardwareStore;

public class Role
{

    public Role(string roleName)
    {   
        RoleName = roleName;
    }
    public Role()
    {
        
    }

    [Key]
    public Guid RoleId { get; set; }
    public string? RoleName { get; set; }    
}
