using _00_Core.Models;

namespace _02_OwnsType.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Address Address { get; set; }
    }
}