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
}

