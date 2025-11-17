using Absolute_Cinema.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Absolute_Cinema.Enteties
{
    public class MoviesContext: IdentityDbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options): base(options) { }

        public DbSet<Movies> Movies { get; set; }
    }
}
