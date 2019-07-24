using System;
using System.Collections.Generic;
using System.Linq;
using _00_Core;
using _00_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _05_LazyLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UefaDbContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //Console.Clear();
                //Insert(context);
                //Update(context);
            }

            UpdateThenError();
        }

        private static void Insert(UefaDbContext context)
        {
            var countries = new List<Country>();
            for (int i = 0; i < 2; i++)
            {
                countries.Add(new Country
                {
                    Name = $"France {i}"
                });
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            countries = new List<Country>();
            for (int i = 0; i < 10; i++)
            {
                countries.Add(new Country
                {
                    Name = $"France {i}"
                });
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();
        }

        private static void Update(UefaDbContext context)
        {
            foreach (var country in context.Countries.TagWith("Update Countries"))
            {
                country.Name = country.Name + " (Updated)";
            }

            context.SaveChanges();
        }

        private static void UpdateThenError()
        {
            SeedData();

            using (var context = new UefaDbContext())
            {
                var team = context.Teams.Find(1);

                var teamToUpdate = new Team()
                {
                    Id = 1,
                    Country = new Country { Id = 1 },
                    Name = "Shahtar (Updated)"
                };

                context.Entry(team).State = EntityState.Detached;

                // track properties related to teamToUpdate only
                context.Entry(teamToUpdate).State = EntityState.Modified;
                teamToUpdate.Name = "Shahtar 77";
                //var country2 = new Country() { Id = 2 };
                //context.Attach(country2);
                //teamToUpdate.Country = country2;

                // track all properties include countries
                //context.Attach(teamToUpdate);
                //teamToUpdate.Name = "Shahtar 77";

                //var country2 = new Country() { Id = 2 };
                //context.Attach(country2);
                //teamToUpdate.Country = country2;

                // update all properties include country
                //context.Teams.Update(teamToUpdate);
                
                //context.Entry(teamToUpdate).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        private static void SeedData()
        {
            using (var context = new UefaDbContext())
            {
                context.Countries.AddRange(new Country()
                {
                    Name = "Ukraine"
                }, new Country()
                {
                    Name = "Spain"
                });

                context.Teams.Add(new Team()
                {
                    Name = "Shahtar"
                });

                context.SaveChanges();
                Console.Clear();
            }
        }
    }
}
