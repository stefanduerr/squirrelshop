namespace Squirrels.Data;
using Microsoft.EntityFrameworkCore;
using squirrels.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<UserProduct> UserProducts { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
}
