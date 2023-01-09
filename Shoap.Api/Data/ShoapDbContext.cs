using Microsoft.EntityFrameworkCore;
using Shoap.Api.Entities;

namespace Shoap.Api.Data;

public class ShoapDbContext : DbContext
{
    public ShoapDbContext()
    {

    }

    //entities
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<User> Users { get; set; }
}

