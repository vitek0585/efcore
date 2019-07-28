using _00_Core.Models;
using _02_OwnsType.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Player = _02_OwnsType.Models.Player;

namespace _02_OwnsType
{
    public class UefaDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer("Server=CREDOLAB-VIPO\\SQLEXPRESS;Database=UEFA2020;Trusted_Connection=True;MultipleActiveResultSets=true")
               .EnableSensitiveDataLogging()
               .UseLoggerFactory(CommandsLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var playerModelBuilder = modelBuilder.Entity<Player>();
            // https://github.com/aspnet/EntityFrameworkCore/issues/16775
            playerModelBuilder.OwnsOne(c => c.Address);
        }

        public static readonly LoggerFactory CommandsLoggerFactory
            = new LoggerFactory(new[] {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true) });
    }
}
