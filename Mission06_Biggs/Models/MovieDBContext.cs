using Microsoft.EntityFrameworkCore;

namespace Mission06_Biggs.Models
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options) 
        { 
        }

        public DbSet<MovieModel> Movies { get; set; }
    }
}
