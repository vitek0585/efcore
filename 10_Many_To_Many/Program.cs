using System;
using System.Linq;
using _00_Core;
using Microsoft.EntityFrameworkCore;

namespace _10_Many_To_Many
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UefaDbContext())
            {
                //context.Database.Migrate();
                //foreach (var player in context.Players.Take(3)
                //                                        .Include(p => p.PlayerFootballAwards)
                //                                        .ThenInclude(fa => fa.FootballAward))
                //{
                //    var awards = player.PlayerFootballAwards?.Select(p => p.FootballAward?.Name).ToList();
                //    Console.WriteLine($"{player.Name} {player.Position} " +
                //                      $"{string.Join(" ,", awards ?? Enumerable.Empty<string>())}");
                //}

               // GetPlayerAwards();
                GetPlayerAwardsImprove();
            };
        }

        private static void GetPlayerAwards()
        {
            using (var context = new UefaDbContext())
                foreach (var player in context.Players.Include(p=>p.PlayerFootballAwards).ThenInclude(a=>a.FootballAward)
                .Select(p => new
                {
                    p.Name,
                    p.Position,
                    awards = p.PlayerFootballAwards.Select(pfa => pfa.FootballAward.Name).ToList()
                }).Take(3).ToList())
                {
                    var awards = player.awards;
                    Console.WriteLine($"{player.Name} {player.Position} " +
                                      $"{string.Join(" ,", awards ?? Enumerable.Empty<string>())}");
                }
        }

        private static void GetPlayerAwardsImprove()
        {
            using (var context = new UefaDbContext())
            {
                context.Database.Migrate();
                Console.Clear();
                var players = context.Players.Include(p => p.PlayerFootballAwards).ThenInclude(a => a.FootballAward);

                var list = players.GroupJoin(context.PlayerFootballAwards.Include(p=>p.FootballAward), p => p.Id, fa => fa.PlayerId, (p, fpa) => new
                {
                    p.Name,
                    p.Position,
                    awards = fpa.Where(f=>f.PlayerId == p.Id).Select(f=>f.FootballAward.Name).ToList()
                        //fpa.Join(context.FootballAwards, pf => pf.FootballAwardId, a => a.Id, 
                        //(pf, a) => a.Name)

                }).Take(3).ToList();
                
                foreach (var player in list)
                {
                    var awards = player.awards;
                    Console.WriteLine($"{player.Name} {player.Position} " +
                                      $"{string.Join(" ,", awards ?? Enumerable.Empty<string>())}");
                }
            }
        }
    }
}
