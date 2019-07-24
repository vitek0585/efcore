using System;
using System.Linq;
using _00_Core;
using Microsoft.EntityFrameworkCore;

namespace _08_GlobalQueryFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UefaDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Console.Clear();

                GetTeams(context);
                GetTeamsByIgnoringFilter(context);
            }
        }

        private static void GetTeams(UefaDbContext context)
        {
            var countries = context.Countries.ToList();
            foreach (var country in countries)
            {
                Console.WriteLine($"{country.Name} {country.isEurope}");
            }
        }

        private static void GetTeamsByIgnoringFilter(UefaDbContext context)
        {
            var teams = context.Teams.Include(t => t.Country).IgnoreQueryFilters().ToList();
            foreach (var team in teams)
            {
                Console.WriteLine($"{team.Name} {team.Country?.Name}");
            }
        }
    }
}
