using Data.Core;
using Data.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Data.Core
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=liquid_code.Core;Integrated Security=True;");
        }



        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
    }
}
