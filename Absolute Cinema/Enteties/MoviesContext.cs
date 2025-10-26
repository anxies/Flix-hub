using Absolute_Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Absolute_Cinema.Enteties
{
    public class MoviesContext: DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options): base(options) { }

        public DbSet<Movies> Movies { get; set; }
    }
}
