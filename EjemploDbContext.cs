using EjemploEFCore;
using Microsoft.EntityFrameworkCore;

public class EjemploDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public EjemploDbContext(DbContextOptions<EjemploDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Order>().ToTable("Orders");
    }
}
