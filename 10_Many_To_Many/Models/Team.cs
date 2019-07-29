using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace _00_Core.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Country Country { get; set; }

        private Collection<Player> _players;
        public virtual Collection<Player> Players
        {
            get { return _lazyLoader.Load(this, ref _players); }
            set { _players = value; }
        }

        public Team() { }
        private ILazyLoader _lazyLoader { get; set; }

        // install-package Microsoft.EntityFrameworkCore.Abstractions
        public Team(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
    }
}