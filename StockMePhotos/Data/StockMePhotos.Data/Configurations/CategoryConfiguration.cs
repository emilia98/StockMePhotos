using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMePhotos.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMePhotos.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        private readonly IEnumerable<Category> Categories = new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Nature & Landscapes",
                Slug = "nature-landscapes",
                Description = "Forests, mountains, beaches, sunsets, and outdoor scenery."
            },
            new Category
            {
                Id = 2,
                Name = "Food & Drinks",
                Slug = "food-drinks",
                Description = "Meals, desserts, beverages, and restaurant-style photography."
            },
            new Category
            {
                Id = 3,
                Name = "People & Lifestyle",
                Slug = "people-lifestyle",
                Description = "Everyday moments, portraits, work, family, and social life."
            },
            new Category
            {
                Id = 4,
                Name = "Business & Technology",
                Slug = "business-technology",
                Description = "Offices, devices, startups, teamwork, and digital life."
            },
            new Category
            {
                Id = 5,
                Name = "Travel & Destinations",
                Slug = "travel-destinations",
                Description = "Cities, landmarks, tourism, and cultural locations."
            },
            new Category
            {
                Id = 6,
                Name = "Fashion & Beauty",
                Slug = "fashion-beauty",
                Description = "Clothing, accessories, cosmetics, and style trends."
            },
            new Category
            {
                Id = 7,
                Name = "Sports & Fitness",
                Slug = "sports-fitness",
                Description = "Training, workouts, competitions, and active lifestyles."
            },
            new Category
            {
                Id = 8,
                Name = "Animals & Wildlife",
                Slug = "animals-wildlife",
                Description = "Pets, farm animals, and wildlife in natural settings."
            },
            new Category
            {
                Id = 9,
                Name = "Architecture & Interiors",
                Slug = "architecture-interiors",
                Description = "Buildings, homes, offices, and interior design."
            },
            new Category
            {
                Id = 10,
                Name = "Art & Creativity",
                Slug = "art-creativity",
                Description = "Painting, music, crafts, design, and creative expression."
            },
        };

        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity
                .Property(c => c.DateAdded)
                .HasDefaultValueSql("GETUTCDATE()");

            entity
                .HasData(Categories);
        }
    }
}
