using System;
using System.Threading.Tasks;
using IkeMtz.NRSRx.Core.Unigration;
using IkeMtz.AdventureWorks.Models;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using IkeMtz.AdventureWorks.Data;
using IkeMtz.AdventureWorks.Tests;

namespace IkeMtz.AdventureWorks.WebApi.Tests.Unigration
{
  [TestClass]
  public partial class OrdersTest : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Unigration")]
    public async Task SaveOrdersTest()
    {
      var item = Factories.OrderFactory();
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationWebApiTestStartup>());
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.PostAsJsonAsync($"api/v1/{nameof(Order)}s.json", item);
      _ = resp.EnsureSuccessStatusCode();
      var httpOrder = await DeserializeResponseAsync<Order>(resp);
      Assert.AreEqual("IntegrationTester@email.com", httpOrder.CreatedBy);

      var dbContext = srv.GetDbContext<DatabaseContext>();
      var dbOrder = await dbContext.Orders.FirstOrDefaultAsync(t => t.Id == item.Id);

      Assert.IsNotNull(dbOrder);
      Assert.AreEqual(httpOrder.CreatedOnUtc, dbOrder.CreatedOnUtc);
    }


    [TestMethod]
    [TestCategory("Unigration")]
    public async Task UpdateOrderTest()
    {
      var originalOrder = Factories.OrderFactory();
      originalOrder.CreatedBy = "blah";
      originalOrder.CreatedOnUtc = DateTime.UtcNow;
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationWebApiTestStartup>()
        .ConfigureTestServices(x =>
        {
          ExecuteOnContext<DatabaseContext>(x, db =>
          {
            _ = db.Orders.Add(originalOrder);
          });
        }));
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var updatedOrder = JsonClone(originalOrder);
      updatedOrder.Comment = TestDataFactory.StringGenerator(6);

      var resp = await client.PutAsJsonAsync($"api/v1/{nameof(Order)}s.json?id={updatedOrder.Id}", updatedOrder);
      _ = resp.EnsureSuccessStatusCode();
      var httpUpdatedOrder = await DeserializeResponseAsync<Order>(resp);
      Assert.AreEqual("IntegrationTester@email.com", httpUpdatedOrder.UpdatedBy);
      Assert.AreEqual(updatedOrder.Comment, httpUpdatedOrder.Comment);
      Assert.IsNull(updatedOrder.UpdatedOnUtc);
      Assert.IsNotNull(httpUpdatedOrder.UpdatedOnUtc);

      var dbContext = srv.GetDbContext<DatabaseContext>();
      var updatedDbOrder = await dbContext.Orders.FirstOrDefaultAsync(t => t.Id == originalOrder.Id);

      Assert.IsNotNull(updatedDbOrder);
      Assert.IsNotNull(updatedDbOrder.UpdatedOnUtc);
      Assert.AreEqual(httpUpdatedOrder.UpdatedOnUtc, updatedDbOrder.UpdatedOnUtc);
    }
  }
}
