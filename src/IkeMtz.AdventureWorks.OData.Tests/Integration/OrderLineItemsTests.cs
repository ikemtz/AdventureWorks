using System;
using System.Linq;
using System.Threading.Tasks;
using IkeMtz.AdventureWorks.Models;
using IkeMtz.NRSRx.Core.Models;
using IkeMtz.NRSRx.Core.Unigration;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace IkeMtz.AdventureWorks.OData.Tests.Integration
{
  [TestClass]
  public partial class OrderLineItemsTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Unigration")] 
    public async Task GetOrderLineItemsTest()
    { 
      using var srv = new TestServer(TestHostBuilder<Startup, IntegrationODataTestStartup>());
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.GetStringAsync($"odata/v1/{nameof(OrderLineItem)}s?$count=true");
      TestContext.WriteLine($"Server Reponse: {resp}");
      var envelope = JsonConvert.DeserializeObject<ODataEnvelope<OrderLineItem>>(resp);
      Assert.AreEqual(envelope.Count, envelope.Value.Count());
      envelope.Value.ToList().ForEach(t =>
      {
        Assert.IsNotNull(t.ProductId);
        Assert.AreNotEqual(Guid.Empty, t.Id);
      });
    }

  }
}
