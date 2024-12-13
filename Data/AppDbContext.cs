namespace Squirrels.Data;
using Microsoft.EntityFrameworkCore;
using squirrels.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    public DbSet<Cart> Cart {get; set;}
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderProduct> CartProducts { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
}
