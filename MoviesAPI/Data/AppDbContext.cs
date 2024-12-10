using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext (DbContextOptions<AppDbContext>options) : 
        base(options) { }
    public DbSet<Movies> Movies { get; set; }
}