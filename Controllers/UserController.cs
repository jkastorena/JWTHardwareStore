using JWTHardwareStore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTHardwareStore.Controllers;

[Route("api/[controller]/{action}")]
[ApiController]
public class UserController : ControllerBase
{

    private HaswContext _haswContext;

    public UserController(HaswContext haswContext)
    {
        _haswContext = haswContext;
    }

    public async Task<IActionResult> GetUsers()
    {
        var users = await _haswContext.Users.ToListAsync();
        return Ok(users);
    }

    public async Task<IActionResult> Register(User user)
    {
        if (user == null) return BadRequest("user empty");

        _haswContext.Users.Add(user);
        await _haswContext.SaveChangesAsync();

        return Ok("The pinche user was created correctly");
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(Role role){
         if (role == null) return BadRequest("Role empty");

        _haswContext.Roles.Add(role);
        await _haswContext.SaveChangesAsync();

        return Ok("Role Created");
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles()
    {
        var roles = await _haswContext.Roles.ToListAsync();
        return Ok(roles);
    }

    [HttpPost]
    public  IActionResult SetUserRole(UserRoleRequest req)
    {

        if (req == null) return BadRequest("Fail");

        var user = _haswContext.Users.FirstOrDefault(q => q.Email == req.Email);
        var role = _haswContext.Roles.FirstOrDefault(q => q.RoleName == req.RoleName);

        if(user == null || role == null) return BadRequest("No Hay");

        //var userRole = new UserRole(
        //    role, 
        //    user
        //    );

        //_haswContext.UsersRoles.AddAsync(userRole);
        //_haswContext.SaveChanges();
        
        return Ok("OK");
    }


   
}

