﻿using System;
using System.Linq;
using System.Threading.Tasks;
using IkeMtz.AdventureWorks.Data;
using IkeMtz.AdventureWorks.Models;
using IkeMtz.AdventureWorks.Tests;
using IkeMtz.NRSRx.Core.Models;
using IkeMtz.NRSRx.Core.Unigration;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace IkeMtz.AdventureWorks.OData.Tests.Unigration
{
  [TestClass]
  public partial class ProductsTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Unigration")]
    public async Task GetProductsTest()
    {
      var obj = Factories.ProductFactory();
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationODataTestStartup>()
          .ConfigureTestServices(x =>
          {
            ExecuteOnContext<DatabaseContext>(x, db =>
            {
              _ = db.Products.Add(obj);
            });
          })
       );
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.GetStringAsync($"odata/v1/{nameof(Product)}s?$count=true&top=5&$expand={nameof(ProductModel)},{nameof(ProductCategory)}");
      TestContext.WriteLine($"Server Reponse: {resp}");
      var envelope = JsonConvert.DeserializeObject<ODataEnvelope<Product>>(resp);
      Assert.AreEqual(envelope.Count, envelope.Value.Count());
      envelope.Value.ToList().ForEach(t =>
      {
        Assert.IsNotNull(t.Name);
        Assert.AreNotEqual(Guid.Empty, t.Id);
      });
    }

  }
}
