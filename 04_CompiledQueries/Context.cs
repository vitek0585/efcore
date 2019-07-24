using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _04_CompiledQueries
{
    public class TestDbContext : DbContext
    {
        private Func<TestDbContext, Category> _getCategoryCompiled =
            EF.CompileQuery((TestDbContext ctx) =>
                ctx.Categories.Include(c => c.Parent)
                    .Where(c => c.Parent == null)
                    .OrderBy(c => c.Name)
                    .FirstOrDefault());
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public void FillCategories()
        {
            var foodCategory = new Category { Id = Guid.NewGuid(), Name = "Food", Parent = null };

            Categories.AddRange(
                foodCategory,
                new Category { Id = Guid.NewGuid(), Name = "Drinks", Parent = null },
                new Category { Id = Guid.NewGuid(), Name = "Clothing", Parent = null },
                new Category { Id = Guid.NewGuid(), Name = "Electronis", Parent = null }
            );

            for (var i = 0; i < 50; i++)
            {
                Categories.Add(new Category { Id = Guid.NewGuid(), Name = "Random", Parent = foodCategory });
            }

            SaveChanges(true);
        }

        public Category GetCategoryUncompiled()
        {
            return Categories.Include(c => c.Parent)
                .Where(c => c.Parent == null)
                .OrderBy(c => c.Name)
                .FirstOrDefault();
        }

        public Category GetCategoryCompile()
        {
            return EF.CompileQuery((TestDbContext ctx) =>
                ctx.Categories.Include(c => c.Parent)
                    .Where(c => c.Parent == null)
                    .OrderBy(c => c.Name)
                    .FirstOrDefault()).Invoke(this);
        }
        public Category GetCategoryCompiled()
        {
            return _getCategoryCompiled(this);
        }
    }

    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Category Parent { get; set; }
    }
}