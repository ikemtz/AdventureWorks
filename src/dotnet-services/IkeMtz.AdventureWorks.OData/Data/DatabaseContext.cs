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
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<ClientAddress> ClientAddresses { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    public virtual DbSet<ProductModel> ProductModels { get; set; }
    public virtual DbSet<SaleOrder> SaleOrders { get; set; }
    public virtual DbSet<SaleOrderAddress> SaleOrderAddresses { get; set; }
    public virtual DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }
  }
}
