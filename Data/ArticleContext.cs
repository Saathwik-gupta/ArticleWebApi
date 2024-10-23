using Microsoft.EntityFrameworkCore;
using ArticleWebApi.Models;
using ArticleWebApi.Models.Mappings;

namespace ArticleWebApi.Data
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options) { }

        // DbSets for each model
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Article_City> Article_Cities { get; set; }
        public DbSet<Article_ArticleGroup> Article_ArticleGroups { get; set; }

        // Method to seed the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding Country data
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "USA" },
                new Country { CountryId = 2, CountryName = "Canada" }
            );

            // Seeding State data
            modelBuilder.Entity<State>().HasData(
                new State { StateId = 1, StateName = "California", CountryId = 1 },
                new State { StateId = 2, StateName = "Ontario", CountryId = 2 }
            );

            // Seeding City data
            modelBuilder.Entity<City>().HasData(
                new City { CityId = 1, CityName = "Los Angeles", StateId = 1 },
                new City { CityId = 2, CityName = "Toronto", StateId = 2 }
            );

            // Seeding Article data
            modelBuilder.Entity<Article>().HasData(
                new Article { ArticleId = 1, Title = "The Great Adventure", Content = "An amazing journey through the mountains." },
                new Article { ArticleId = 2, Title = "Culinary Delights", Content = "Exploring the best dishes from around the world." }
            );

            // Seeding ArticleGroup data
            modelBuilder.Entity<ArticleGroup>().HasData(
                new ArticleGroup { ArticleGroupId = 1, GroupName = "Travel" },
                new ArticleGroup { ArticleGroupId = 2, GroupName = "Food" }
            );

            // Seeding Package data
            modelBuilder.Entity<Package>().HasData(
                new Package { PackageId = 1, PackageName = "Adventure Package", Price = 499.99m, ArticleGroupId = 1 },
                new Package { PackageId = 2, PackageName = "Gourmet Package", Price = 299.99m, ArticleGroupId = 2 }
            );

            // Seeding ArticleArticleGroup mapping data
            modelBuilder.Entity<Article_ArticleGroup>().HasData(
                new Article_ArticleGroup { Id = 1, ArticleId = 1, ArticleGroupId = 1 },
                new Article_ArticleGroup { Id = 2, ArticleId = 2, ArticleGroupId = 2 }
            );

            // Seeding ArticleCity mapping data
            modelBuilder.Entity<Article_City>().HasData(
                new Article_City { Id = 1, ArticleId = 1, CityId = 1 },
                new Article_City { Id = 2, ArticleId = 2, CityId = 2 }
            );
        }
    }
}
