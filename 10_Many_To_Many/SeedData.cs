﻿using _00_Core.Models;
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

            modelBuilder.Entity<FootballAward>().HasData(new FootballAward
            {
                Id = 1,
                Name = "Golden Ball"
            });

            modelBuilder.Entity<PlayerFootballAward>().HasData(new PlayerFootballAward
            {
                PlayerId = 1,
                FootballAwardId = 1
            },
                new PlayerFootballAward
                {
                    PlayerId = 2,
                    FootballAwardId = 1
                });
        }
    }
}