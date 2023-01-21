using Microsoft.EntityFrameworkCore;
using Shoap.Api.Entities;

namespace Shoap.Api.Data;

public class ShoapDbContext : DbContext
{
    public ShoapDbContext(DbContextOptions<ShoapDbContext> options) : base(options)
    {

    }

    //entities
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
}

