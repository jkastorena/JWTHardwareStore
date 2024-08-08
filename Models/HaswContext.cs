using Microsoft.EntityFrameworkCore;

namespace JWTHardwareStore;

public class HaswContext : DbContext
{
    public HaswContext(DbContextOptions options) : base(options){}

    public DbSet<User> Users {get; set;}
    
}


