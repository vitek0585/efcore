using System;
using System.Linq;
using _00_Core;
using Microsoft.EntityFrameworkCore;

namespace _07_Sql
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new UefaDbContext())
            //{
            //    context.Database.EnsureDeleted();
            //    context.Database.EnsureCreated();
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        context.Teams.Add(new Team() { CountryId = 1, Name = "Dynamo" });
            //    }
            //    context.SaveChanges();
            //    Console.Clear();
            //}

            GroupByClientSide();
            GroupByServerSide();
            GroupByThrowError();
            GroupByFixError();
        }

        private static void GroupByClientSide()
        {
            using (var context = new UefaDbContext())
            {
                foreach (var teams in context.Teams
                    .Where(t => EF.Functions.Like(t.Name, "D%")).TagWith("CLIENT SIDE")
                    .GroupBy(t => t.Name).ToList())
                {
                    Console.WriteLine($"{teams.Key} {teams.Count()}");
                }
            }
        }

        private static void GroupByServerSide()
        {
            using (var context = new UefaDbContext())
            {
                foreach (var teams in context.Teams
                    .Where(t => EF.Functions.Like(t.Name, "D%")).TagWith("SERVER SIDE")
                    .GroupBy(t => t.Name)
                    .Select(t => new { Name = t.Key, Count = t.Count() })
                    .ToList())
                {
                    Console.WriteLine($"{teams.Name} {teams.Count}");
                }
            }
        }

        // https://github.com/aspnet/EntityFrameworkCore/issues/12560
        private static void GroupByThrowError()
        {
            using (var context = new UefaDbContext())
            {
                try
                {
                    foreach (var teams in context.Teams
                        .GroupBy(t => new { t.Name, t.Country.Id }).TagWith("THROW ERROR")
                        .Select(t => new
                        {
                            t.Key.Name,
                            Country = context.Countries.Where(c => c.Id == t.Key.Id).FirstOrDefault()
                        }).ToList())
                    {
                        Console.WriteLine($"{teams.Name} {teams.Country.Name}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private static void GroupByFixError()
        {
            using (var context = new UefaDbContext())
            {
                foreach (var teams in context.Teams
                    .GroupBy(t => new { t.Name, t.Country.Id }).TagWith("FIX ERROR")
                    .Select(t => new { t.Key.Name, t.Key.Id })
                    .ToList()
                    .Select(t => new
                    {
                        t.Name,
                        Country = context.Countries.Where(c => c.Id == t.Id).FirstOrDefault()

                    }).ToList())
                {
                    Console.WriteLine($"{teams.Name} {teams.Country.Name}");
                }
            }
        }
    }
}
