using Foodies.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foodies.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Foodies.Models.Category> Categories { get; set; }
        public DbSet<Foodies.Models.FoodItem> FoodItems { get; set; }

        public DbSet<Foodies.Models.ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Foodies.Models.Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //HasKey(m => m.Guid)
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FoodItem>().HasKey(m => m.FoodId);
            modelBuilder.Entity<Category>().HasKey(m => m.CategoryId);
            modelBuilder.Entity<FoodItem>().HasData(
                new FoodItem
                {
                    FoodId = 1,
                    FoodName = "Dosa",
                    FoodDescription = "South Indian Special",
                    Price = 40,
                    ImageUrl = "/Images/dosa.jpg",
                    ImageThumbnailUrl = "/Images/dosa.jpg",
                    IsAvailable = true,
                    IsTodaySpecial = true,
                    HasDiscount = false,
                    CategoryId = 1
                });

            modelBuilder.Entity<FoodItem>().HasData(
            new FoodItem
            {
                FoodId = 2,
                FoodName = "Anda Sandwitch",
                FoodDescription = "Special Anda Sandwitch",
                Price = 30,
                ImageUrl = "/Images/eggsandwith.jpg",
                ImageThumbnailUrl = "/Images/eggsandwith.jpg",
                IsAvailable = true,
                IsTodaySpecial = true,
                HasDiscount = false,
                CategoryId = 2
            });

            modelBuilder.Entity<FoodItem>().HasData(
            new FoodItem
            {
                FoodId = 3,
                FoodName = "Biryani",
                FoodDescription = "Hyderabadi Dum Biryani",
                Price = 120,
                ImageUrl = "/Images/biryani.jpg",
                ImageThumbnailUrl = "/Images/biryani.jpg",
                IsAvailable = true,
                IsTodaySpecial = true,
                HasDiscount = false,
                CategoryId = 1
            });

            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryId = 1,
                CategoryName = "Vegeterian",
                Description = "Pure Vegeterian Dishes"
            });

            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryId = 2,
                CategoryName = "Eggterian",
                Description = "FoodItems with Egg"
            });

            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryId = 3,
                CategoryName = "Non-Vegeterian",
                Description = "Delicious Dishes of Non-Vegeterian"
            });
        }
    }
}
