using Microsoft.EntityFrameworkCore;

namespace _00_Domain
{
    public partial class SeedData
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            SeedInternal(modelBuilder);
        }

        partial void SeedInternal(ModelBuilder modelBuilder)
        {

        }
    }
}