using System;
using Microsoft.EntityFrameworkCore;

namespace Laboration1.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        //public DbSet<Artist> Artists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = "server = localhost; database = animal; user = tim; password = 12345678";
            options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString));
        }
    }
}