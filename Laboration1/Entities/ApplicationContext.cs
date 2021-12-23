using System;
using Microsoft.EntityFrameworkCore;

namespace Laboration1.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
       
        private string _connectionString = "server = localhost; database = animal; user = tim; password = 12345678";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //var connectionString = "server = localhost; database = animal; user = tim; password = 12345678";
            options.UseMySql(
                _connectionString,
                ServerVersion.AutoDetect(_connectionString));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AnimalType>().HasData(
                new AnimalType
                {
                    Id = 1,
                    Name = "Frogg"
                },
                new AnimalType
                {
                    Id = 2,
                    Name = "Fish"
                },
                new AnimalType
                {
                    Id = 3,
                    Name = "Bird"
                }
                );

            builder.Entity<Animal>().HasData(
                new Animal
                {
                    Id = 1,
                    AnimaltypeID = 1,
                    Name = "Al"
                },
                new Animal
                {
                    Id = 2,
                    AnimaltypeID = 1,
                    Name = "Pet"
                },
                new Animal
                {
                    Id = 3,
                    AnimaltypeID = 2,
                    Name = "Jim"
                },
                new Animal
                {
                    Id = 4,
                    AnimaltypeID = 3,
                    Name = "Fred"
                },
                new Animal
                {
                    Id = 5,
                    AnimaltypeID = 3,
                    Name = "Mike"
                }
                );
        }
    }
}