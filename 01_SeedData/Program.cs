using System;
using _00_Core;
using Microsoft.EntityFrameworkCore;

namespace _01_SeedData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UefaDbContext())
            {
                context.Database.Migrate();
                foreach (var team in context.Teams)
                {
                    Console.WriteLine($"{team.Name} {team.Country?.Name}");
                }
            }
        }
    }
}
