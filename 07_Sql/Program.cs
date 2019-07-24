using System;
using System.Linq;
using _00_Core;
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
            //SelectByName();
            //SelectByNameInjetion();
            //SelectByNameAndOrder();
            SelectByNameLinq();
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
    }
}
