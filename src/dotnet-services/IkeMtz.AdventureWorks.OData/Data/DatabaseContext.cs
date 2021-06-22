using IkeMtz.AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace IkeMtz.AdventureWorks.OData.Data
{
  public class DatabaseContext : DbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    public virtual DbSet<ProductModel> ProductModels { get; set; }
    public virtual DbSet<SaleOrder> SaleOrders { get; set; }
    public virtual DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }
  }
}
