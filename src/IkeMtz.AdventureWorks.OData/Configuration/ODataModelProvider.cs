﻿using System.Collections.Generic;
using IkeMtz.AdventureWorks.Models;
using IkeMtz.NRSRx.Core.OData;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OData.Edm;

namespace IkeMtz.AdventureWorks.OData.Configuration
{
  public class ODataModelProvider : BaseODataModelProvider
  {
    public static IEdmModel GetV1EdmModel() =>
      ODataEntityModelFactory(builder =>
      {
        _ = builder.EntitySet<Customer>($"{nameof(Customer)}s");
        _ = builder.EntitySet<CustomerAddress>($"{nameof(CustomerAddress)}es");
        _ = builder.EntitySet<OrderAddress>($"{nameof(OrderAddress)}es");
        _ = builder.EntitySet<Product>($"{nameof(Product)}s");
        _ = builder.EntitySet<ProductCategory>($"{nameof(Product)}Categories");
        _ = builder.EntitySet<ProductModel>($"{nameof(ProductModel)}s");
        _ = builder.EntitySet<Order>($"{nameof(Order)}s");
        _ = builder.EntitySet<OrderLineItem>($"{nameof(OrderLineItem)}s");
        _ = builder.EntitySet<SalesAgent>($"{nameof(SalesAgent)}s");
      });

    public override IDictionary<ApiVersionDescription, IEdmModel> GetModels() =>
        new Dictionary<ApiVersionDescription, IEdmModel>
        {
          [ApiVersionFactory(1, 0)] = GetV1EdmModel(),
        };
  }
}
