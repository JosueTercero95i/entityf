using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EjemploEFCore
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<EjemploDbContext>(options =>
                    options.UseSqlServer(Conexion.ConnectionString)) 
                .BuildServiceProvider();

            using (var context = serviceProvider.GetService<EjemploDbContext>())
            {
                var customer = context.Customers.FirstOrDefault();
                if (customer != null)
                {
                    Console.WriteLine($"Customer: {customer.CompanyName}, Contact: {customer.ContactName}");
                }
                else
                {
                    Console.WriteLine("No customers found.");
                }
            }

        }
    }
}
