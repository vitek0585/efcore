namespace _00_Core.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Team Team { get; set; }
    }
}