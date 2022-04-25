using IkeMtz.AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace IkeMtz.AdventureWorks.Data
{
  public partial class DatabaseContext 
  { 
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    public virtual DbSet<ProductModel> ProductModels { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderAddress> OrderAddresses { get; set; }
    public virtual DbSet<OrderLineItem> OrderLineItems { get; set; }
    public virtual DbSet<SalesAgent> SalesAgents { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Order>().HasOne(order => order.BillToAddress).WithMany(address => address.BillToOrders);
      modelBuilder.Entity<Order>().HasOne(order => order.ShipToAddress).WithMany(address => address.ShipToOrders);
      base.OnModelCreating(modelBuilder);
    }
  }
}
