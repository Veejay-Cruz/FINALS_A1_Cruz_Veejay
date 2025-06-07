using backend.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.Data
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
            : base(options)
        {
        }



        // Define DbSets for your entities here
        // For example:
        public DbSet<Recipe> Recipes { get; set; }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    // Configure entity properties and relationships here
        //    // For example:
        //    // modelBuilder.Entity<Recipe>().HasKey(r => r.Id);
        //    // modelBuilder.Entity<Ingredient>().HasKey(i => i.Id);
        //}
    }
}
