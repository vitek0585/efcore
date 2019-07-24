namespace _00_Core.Models
{
    public class PlayerFootballAward
    {
        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int FootballAwardId { get; set; }

        public FootballAward FootballAward { get; set; }
    }
}