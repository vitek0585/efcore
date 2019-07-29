using System;
using System.Diagnostics;
using System.Linq;
using _00_Core;
using _00_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _04_CompiledQueries
{
    class Program
    {
        //This feature allows applications to cache the translation of queries so that they are computed only once
        //and executed several times.This approach helps to gain performance for the application.

        //Now we have query for loading categories by id built once and calls to GetCategory() method don’t have to compile the query again.Notice that query compiling happens in static scope meaning that once built the query is used by all instances of ApplicationDbContext class. There are no threading issues between requests as each call to _getCategory func is using the instance of database context we provide with method call.

        //  Compiled queries in Entity Framework Core are LINQ queries that are compiled in application or library to be sent to database server. From database server view point it is the client-side feature and it is not related to precompiling views and SQL commands in database server. 
        static void Main(string[] args)
        {
            //MeasureUncompiledQuery();
            //MeasureCompileQuery();
            //MeasureCompiledQuery();

            CompileAttention();
        }

        private static void CompileAttention()
        {
            using (var context = new UefaDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var cq = EF.CompileQuery((UefaDbContext ctx) => ctx.Players.Where(p => StartsWith(p)));
                var players = cq(context);
                foreach (var player in players)
                {
                    Console.WriteLine($"{player.Name} {player.Address?.City}");
                }
            }
        }

        private static bool StartsWith(Player p)
        {
            return p.Name.StartsWith("M");
        }

        private static void MeasureCompileQuery()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TestDbContext(options);

            var watch = new Stopwatch();
            var cycles = 1000;
            context.FillCategories();

            watch.Start();
            for (var i = 0; i < cycles; i++) { context.GetCategoryCompile(); }
            watch.Stop();

            Console.Write("Compile: ");
            Console.WriteLine(watch.Elapsed);
        }

        private static void MeasureUncompiledQuery()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TestDbContext(options);
            var watch = new Stopwatch();
            var cycles = 1000;

            context.FillCategories();
            watch.Start();

            for (var i = 0; i < cycles; i++)
            {
                context.GetCategoryUncompiled();
            }
            watch.Stop();

            Console.Write("Uncompiled query: ");
            Console.WriteLine(watch.Elapsed);
        }

        private static void MeasureCompiledQuery()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TestDbContext(options);
            var watch = new Stopwatch();
            var cycles = 1000;

            context.FillCategories();
            watch.Start();

            for (var i = 0; i < cycles; i++)
            {
                context.GetCategoryCompiled();
            }
            watch.Stop();

            Console.Write("Compiled query: ");
            Console.WriteLine(watch.Elapsed);
        }
    }
}
