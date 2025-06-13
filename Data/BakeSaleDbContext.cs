using Microsoft.EntityFrameworkCore;
using BakeSale.Models;

namespace BakeSale.Data
{
    public class BakeSaleDbContext : DbContext
    {
        public BakeSaleDbContext(DbContextOptions<BakeSaleDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Brownie", Price = 0.65m, Quantity = 48, IsFixedStock = true, ImageName = "Brownie.jpg"},
                new Item { Id = 2, Name = "Muffin", Price = 1.00m, Quantity = 36, IsFixedStock = true, ImageName = "Muffin.jpg" },
                new Item { Id = 3, Name = "Cake Pop", Price = 1.35m, Quantity = 24, IsFixedStock = true, ImageName = "Cake_Pop.jpg"  },
                new Item { Id = 4, Name = "Apple Tart", Price = 1.50m, Quantity = 60, IsFixedStock = true, ImageName = "Apple_Tart.jpg"  },
                new Item { Id = 5, Name = "Water", Price = 1.50m, Quantity = 30, IsFixedStock = true, ImageName = "Water.jpg"  },

                new Item { Id = 6, Name = "Shirt", Price = 2.00m, Quantity = 0, IsFixedStock = false, ImageName = "Shirt.jpg"  },
                new Item { Id = 7, Name = "Pants", Price = 3.00m, Quantity = 0, IsFixedStock = false, ImageName = "Pants.jpg"  },
                new Item { Id = 8, Name = "Jacket", Price = 4.00m, Quantity = 0, IsFixedStock = false, ImageName = "Jacket.jpg"  },
                new Item { Id = 9, Name = "Toy", Price = 1.00m, Quantity = 0, IsFixedStock = false, ImageName = "Toy.jpg"  }
            );
        }
    }   
}