using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using _00_Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace _00_Core
{
    public class UefaDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer("Server=VIKTOR-PC\\SQLEXPRESS2016;Database=UEFA2020;Trusted_Connection=True;MultipleActiveResultSets=true")
               .EnableSensitiveDataLogging()
               .UseLoggerFactory(CommandsLoggerFactory);

            //optionsBuilder.ConfigureWarnings(warning =>
            //    warning.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany(c => c.Players);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Country)
                .WithMany(c => c.Teams)
                .HasForeignKey(t => t.CountryId);

            modelBuilder.Entity<Country>()
                .ToTable("Countries");

            modelBuilder.Entity<Country>()
                .Property(c => c.Name)
                .ValueGeneratedOnAdd()
                .IsRequired();

            SeedData.Seed(modelBuilder);
        }

        public static readonly LoggerFactory CommandsLoggerFactory
            = new LoggerFactory(new[] {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true) });
    }
}
