using IkeMtz.AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace IkeMtz.AdventureWorks.Data
{
  public partial class DatabaseContext 
  { 
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<ClientAddress> ClientAddresses { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    public virtual DbSet<ProductModel> ProductModels { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderAddress> OrderAddresses { get; set; }
    public virtual DbSet<OrderLineItem> OrderLineItems { get; set; }
  }
}
