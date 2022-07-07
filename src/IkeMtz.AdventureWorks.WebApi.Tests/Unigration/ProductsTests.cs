using System;
using System.Threading.Tasks;
using IkeMtz.AdventureWorks.Data;
using IkeMtz.AdventureWorks.Models;
using IkeMtz.AdventureWorks.Tests;
using IkeMtz.NRSRx.Core.Unigration;
using IkeMtz.NRSRx.Core.Unigration.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IkeMtz.AdventureWorks.WebApi.Tests.Unigration
{
  [TestClass]
  public partial class ProductsTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Unigration")]
    public async Task SaveProductsTest()
    {
      var item = Factories.ProductFactory();
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationWebApiTestStartup>());
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.PostAsJsonAsync($"api/v1/{nameof(Product)}s.json", item);
      _ = resp.EnsureSuccessStatusCode();
      var httpProduct = await DeserializeResponseAsync<Product>(resp);
      Assert.AreEqual("IntegrationTester@email.com", httpProduct.CreatedBy);

      var dbContext = srv.GetDbContext<DatabaseContext>();
      var dbProduct = await dbContext.Products.FirstOrDefaultAsync(t => t.Id == item.Id);

      Assert.IsNotNull(dbProduct);
      Assert.AreEqual(httpProduct.CreatedOnUtc, dbProduct.CreatedOnUtc);
    }


    [TestMethod]
    [TestCategory("Unigration")]
    public async Task UpdateProductTest()
    {
      var originalProduct = Factories.ProductFactory();
      originalProduct.CreatedBy = "blah";
      originalProduct.CreatedOnUtc = DateTime.UtcNow;
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationWebApiTestStartup>()
        .ConfigureTestServices(x =>
        {
          ExecuteOnContext<DatabaseContext>(x, db =>
          {
            _ = db.Products.Add(originalProduct);
          });
        }));
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var updatedProduct = JsonClone(originalProduct);
      updatedProduct.Name = TestDataFactory.StringGenerator(6);

      var resp = await client.PutAsJsonAsync($"api/v1/{nameof(Product)}s.json?id={updatedProduct.Id}", updatedProduct);
      _ = resp.EnsureSuccessStatusCode();
      var httpUpdatedProduct = await DeserializeResponseAsync<Product>(resp);
      Assert.AreEqual("IntegrationTester@email.com", httpUpdatedProduct.UpdatedBy);
      Assert.AreEqual(updatedProduct.Name, httpUpdatedProduct.Name);
      Assert.IsNull(updatedProduct.UpdatedOnUtc);
      Assert.IsNotNull(httpUpdatedProduct.UpdatedOnUtc);

      var dbContext = srv.GetDbContext<DatabaseContext>();
      var updatedDbProduct = await dbContext.Products.FirstOrDefaultAsync(t => t.Id == originalProduct.Id);

      Assert.IsNotNull(updatedDbProduct);
      Assert.IsNotNull(updatedDbProduct.UpdatedOnUtc);
      Assert.AreEqual(httpUpdatedProduct.UpdatedOnUtc, updatedDbProduct.UpdatedOnUtc);
    }

  }
}
