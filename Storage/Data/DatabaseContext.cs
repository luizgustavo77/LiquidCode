using Data.Storage.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Storage
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=liquid_code.Storage;Integrated Security=True;");
        }

        public DbSet<Coffee> Coffees { get; set; }
    }
}
