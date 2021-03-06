using System.Data.Common;
using webShop.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;


namespace webShop.Repository;

public class WebShopDbContext : DbContext
{
    public DbSet<ShopItem> ShopItems { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options)
    {
        Seed();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>()
            .HasOne(x => x.Customer)
            .WithMany(x => x.Orders);

        modelBuilder.Entity<Order>()
            .HasMany(s => s.Items);

    }


    private void Seed()
    {
        ShopItems.Add(
            new ShopItem
            {
                Name = "IPhone 13",
                Description = "All-round Apple flagship device backing ground-breaking technology",
                Price = 800,
                ImagePath = "Assets/iphone_13.png"
            }
        );
        ShopItems.Add(
            new ShopItem
            {
                Name = "Oneplus 10 Pro",
                Description = "Oneplus's latest bombshell flagship",
                Price = 1000,
                ImagePath = "Assets/oneplus_10pro.png"
            }
        );
        ShopItems.Add(
            new ShopItem
            {
                Name = "Samsung Galaxy S22 Ultra",
                Description = "Latest installment in the S Ultra generation offering up to 16GB of RAM memory",
                Price = 1200,
                ImagePath = "Assets/samsung_galaxy_s22Ultra.webp"
            }
        );
        SaveChanges();
    }
}