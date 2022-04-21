using System.Threading.Tasks;
using IkeMtz.AdventureWorks.Data;
using IkeMtz.AdventureWorks.Models;
using IkeMtz.AdventureWorks.Tests;
using IkeMtz.NRSRx.Core.Unigration;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IkeMtz.AdventureWorks.WebApi.Tests.Unigration
{
  [TestClass]
  public partial class OrderLineItemsTests : BaseUnigrationTests
  {

    [TestMethod]
    [TestCategory("Unigration")]
    public async Task DeleteOrderLineItemTest()
    {
      var orderLineItem = Factories.OrderLineItemFactory(); 
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationWebApiTestStartup>()
        .ConfigureTestServices(x =>
        {
          ExecuteOnContext<DatabaseContext>(x, db =>
          {
            _ = db.OrderLineItems.Add(orderLineItem);
          });
        }));
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken()); 

      var resp = await client.DeleteAsync($"api/v1/{nameof(OrderLineItem)}s.json?id={orderLineItem.Id}");
      _ = resp.EnsureSuccessStatusCode(); 

      var dbContext = srv.GetDbContext<DatabaseContext>();
      var dbOrderLineItem = await dbContext.Orders.FirstOrDefaultAsync(t => t.Id == orderLineItem.Id);

      Assert.IsNull(dbOrderLineItem);
    }
  }
}
