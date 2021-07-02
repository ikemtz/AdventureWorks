using IkeMtz.AdventureWorks.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;

namespace IkeMtz.AdventureWorks.OData.Configuration
{
  public class ModelConfiguration : IModelConfiguration
  {
    public void Apply(ODataModelBuilder builder, ApiVersion apiVersion, string routePrefix)
    {
      _ = builder.EntitySet<Client>($"{nameof(Client)}s");
      _ = builder.EntitySet<ClientAddress>($"{nameof(ClientAddress)}es");
      _ = builder.EntitySet<SaleOrderAddress>($"{nameof(SaleOrderAddress)}es");
      _ = builder.EntitySet<Product>($"{nameof(Product)}s");
      _ = builder.EntitySet<ProductCategory>($"{nameof(Product)}Categories");
      _ = builder.EntitySet<ProductModel>($"{nameof(ProductModel)}s");
      _ = builder.EntitySet<SaleOrder>($"{nameof(SaleOrder)}s");
      _ = builder.EntitySet<SaleOrderDetail>($"{nameof(SaleOrderDetail)}s");
    }
  }
}
