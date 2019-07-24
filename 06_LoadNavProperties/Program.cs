using System;
using System.Linq;
using _00_Core;
using _00_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _06_LoadNavProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new FifaDbContext())
            //{
            //    context.Database.Migrate();
            //    foreach (var team in context.Teams.Include(t => t.Country))
            //    {
            //        Console.WriteLine($"{team.Name} {team.Country?.Name}");
            //    }
            //}

            using (var context = new UefaDbContext())
            {
                foreach (var team in context.Teams)
                {
                    //context.Entry(team)
                    //    .Reference<Country>(t => t.Country)
                    //    .Load();

                    context.Entry(team)
                        .Reference<Country>(t => t.Country)
                        .Query()
                        .Where(c => c.Name.Equals("Ukraine"));

                    //context.Entry(team)
                    //    .Collection<Player>(t => t.Players)
                    //    .Query()
                    //    .Where(c => c.Name.Equals("Ukraine"));

                    Console.WriteLine($"{team.Name} {team.Country?.Name}");
                }
            }

            //using (var context = new FifaDbContext())
            //{
            //    foreach (var team in context.Teams.Select(t => new { t.Name, t.Country }))
            //    {
            //        Console.WriteLine($"{team.Name} {team.Country?.Name}");
            //    }
            //}

            //using (var context = new FifaDbContext())
            //{
            //    context.ChangeTracker.LazyLoadingEnabled = true;
            //    foreach (var team in context.Teams)
            //    {
            //        Console.WriteLine($"{team.Name} {team.Country?.Name}");
            //    }
            //}

            //using (var context = new FifaDbContext())
            //{
            //    foreach (var team in context.Teams)
            //    {
            //        Console.WriteLine($"{team.Name} {team.Players?.Count}");
            //    }
            //}
        }
    }
}
