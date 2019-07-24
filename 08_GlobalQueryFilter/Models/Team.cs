using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace _00_Core.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Country Country { get; set; }
    }
}