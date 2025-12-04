using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Data
{
    // Ova klasa je posrednik između naše aplikacije i baze podataka
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Ovo će kreirati tablicu "Movies" u bazi
        public DbSet<Movie> Movies { get; set; }
    }
}