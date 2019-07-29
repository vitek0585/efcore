using System.Collections.ObjectModel;

namespace _00_Core.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }
        public virtual Collection<Player> Players { get; set; }
    }
}