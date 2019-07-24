using System.Collections.Generic;

namespace _00_Core.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Team> Teams { get; set; }

        public bool isEurope { get; set; }
    }
}