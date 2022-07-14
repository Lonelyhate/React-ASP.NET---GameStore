using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Models.Games;

namespace server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Game> Games { get; set; }
    
    public DbSet<User> Users { get; set; }
}