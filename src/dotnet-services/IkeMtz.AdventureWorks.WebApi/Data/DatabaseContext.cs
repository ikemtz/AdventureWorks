using IkeMtz.AdventureWorks.Models;
using IkeMtz.NRSRx.Core.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace IkeMtz.AdventureWorks.WebApi.Data
{
  public class DatabaseContext : AuditableDbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options, httpContextAccessor)
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
