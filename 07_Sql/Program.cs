using System;
using System.Linq;
using _00_Core;
using _00_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _07_Sql
{
    class Program
    {
        // EF 6
        //DbSet.SqlQuery()
        //DbContext.Database.SqlQuery()
        //DbContext.Database.ExecuteSqlCommand()

        // EF core
        //DbSet<TEntity>.FromSql()
        //DbContext.Database.ExecuteSqlCommand()

        //FromSql Limitations
        //SQL queries must return entities of the same type as DbSet<T> type.e.g.the specified query cannot return the Course entities if FromSql is used after Students.Returning ad-hoc types from FromSql() method is in the backlog.
        //    The SQL query must return all the columns of the table. e.g.context.Students.FromSql("Select StudentId, LastName from Students).ToList() will throw an exception.
        //The SQL query cannot include JOIN queries to get related data.Use Include method to load related entities after FromSql() method.
        static void Main(string[] args)
        {
            using (var context = new UefaDbContext())
            {
                //context.Database.EnsureDeleted();
                context.Database.Migrate();
                Console.Clear();
            }

            //SelectByName();
            //SelectByNameInjetion();
            //SelectByNameAndOrder();
            //SelectByNameLinq();
            //GetTeamsUseDbFunc();
            GroupBy();
        }

        private static void GroupBy()
        {
            using (var context = new UefaDbContext())
            {
                //for (int i = 0; i < 1000; i++)
                //{
                //    context.Teams.Add(new Team() { CountryId = 1, Name = "Dynamo" });
                //}
                //    context.SaveChanges();

                // foreach (var teams in context.Teams.Where(t => EF.Functions.Like(t.Name, "D%")).GroupBy(t =>t.Name).ToList())
                // foreach (var teams in context.Teams.GroupBy(t =>t.Name).Select(t=>new {t.Key, Count = t.Count()}).ToList())
                // https://github.com/aspnet/EntityFrameworkCore/issues/12560
                foreach (var teams in context.Teams
                    .GroupBy(t =>new {t.Name, t.Country.Id})
                    .Select(t => new { t.Key.Name, t.Key.Id })
                    .ToList()
                    .Select(t=>new {
                        t.Name,
                        Country = context.Countries.Where(c=>c.Id == t.Id).FirstOrDefault()

                    }).ToList())
                {
                    //Console.WriteLine($"{teams.Key} {teams.Count()}");
                    Console.WriteLine($"{teams.Name} {teams.Country.Name}");
                }
            }
        }

        private static void SelectByName()
        {
            using (var context = new UefaDbContext())
            {
                var fcShahtar = "Shahtar";
                var teams = context.Teams.FromSql($"select * from Teams Where Name like {fcShahtar}").ToList();
                foreach (var team in teams) { Console.WriteLine($"{team.Name} {team.Players?.Count}"); }
            }
        }

        private static void SelectByNameInjetion()
        {
            using (var context = new UefaDbContext())
            {
                var fcShahtar = "Shahtar";
                var query = $"select * from Teams Where Name like '{fcShahtar}'";
                var teams = context.Teams.FromSql(query).ToList();
                foreach (var team in teams) { Console.WriteLine($"{team.Name} {team.Players?.Count}"); }
            }
        }

        private static void SelectByNameAndOrder()
        {
            using (var context = new UefaDbContext())
            {
                var s = @"M%";
                var players = context.Players
                    .FromSql($@"select * from Players Where Name like {s} ESCAPE '\'")
                    .OrderByDescending(p => p.Id)
                    .Include(p => p.Team)
                    .ToList();

                foreach (var player in players) { Console.WriteLine($"{player.Id} {player.Name} {player.Team?.Name}"); }
            }
        }

        private static void SelectByNameLinq()
        {
            using (var context = new UefaDbContext())
            {
                var s = @"%l%";
                var players = context.Players
                    .Where(p => EF.Functions.Like(p.Name, s))
                    //.Where(p => p.Name.Contains(s))
                    .OrderByDescending(p => p.Id)
                    .Include(p => p.Team)
                    .ToList();

                foreach (var player in players) { Console.WriteLine($"{player.Id} {player.Name} {player.Team?.Name}"); }
            }
        }
        private static void GetTeamsUseDbFunc()
        {
            using (var context = new UefaDbContext())
            {

                var teams = context.Teams.FromSql("select * from GetTeams()")
                    .Include(t => t.Players)
                    .OrderBy(t => t.CountryId);
                foreach (var team in teams) { Console.WriteLine($"{team.Name} {team.Players?.Count}"); }
            }
        }
    }
}
