using _00_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _00_Core
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country
            {
                Id = 1,
                Name = "Ukraine",
                isEurope = true
            },
                new Country
                {
                    Id = 2,
                    Name = "Spain",
                    isEurope = true
                },
                new Country
                {
                    Id = 3,
                    Name = "USA",
                    isEurope = false
                });

            modelBuilder.Entity<Team>().HasData(new
            {
                Id = 1,
                Name = "Dynamo",
                CountryId = 1
            },
            new
            {
                Id = 2,
                Name = "Shahtar",
                CountryId = 1
            });

            modelBuilder.Entity<Player>().HasData(new 
            {
                Id = 1,
                Name = "Rakitskiy",
                TeamId = 1
            },
                new 
                {
                    Id = 2,
                    Name = "Milevskiy",
                    TeamId = 1
                });

        }
    }
}