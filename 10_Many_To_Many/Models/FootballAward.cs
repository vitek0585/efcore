using System.Collections.Generic;

namespace _00_Core.Models
{
    public class FootballAward
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PlayerFootballAward> PlayerFootballAwards { get; set; }
    }
}