using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext( DbContextOptions<MenuContext> options ) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);


            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id=1, Name= "Margheritta", Price= 250, ImageUrl= "https://www.sorrentina.in/cdn/shop/articles/Classic_Margherita_Pizza_Recipe.webp?v=1688396952" }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id=  1, Name= "Tomato Sauce"},
                new Ingredient { Id = 2, Name = "Mozzarella" },
                new Ingredient { Id = 3, Name = "Oniio"},
                new Ingredient { Id = 4, Name = "Veggies" },
                new Ingredient { Id = 5, Name = "Tomato" }
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId=  1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 },
                new DishIngredient { DishId = 2, IngredientId = 3 },
                new DishIngredient { DishId = 3, IngredientId = 4 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }  
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
