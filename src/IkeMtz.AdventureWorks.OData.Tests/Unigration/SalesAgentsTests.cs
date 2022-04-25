using System;
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
  public partial class SalesAgentsTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Unigration")]
    public async Task GetSalesAgentsTest()
    {
      var obj = Factories.SalesAgentFactory();
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationODataTestStartup>()
          .ConfigureTestServices(x =>
          {
            ExecuteOnContext<DatabaseContext>(x, db =>
            {
              _ = db.SalesAgents.Add(obj);
            });
          })
       );
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.GetStringAsync($"odata/v1/{nameof(SalesAgent)}s?$count=true&top=5&$expand={nameof(Customer)}s");
      TestContext.WriteLine($"Server Reponse: {resp}");
      var envelope = JsonConvert.DeserializeObject<ODataEnvelope<SalesAgent, int>>(resp);
      Assert.AreEqual(envelope.Count, envelope.Value.Count());
      envelope.Value.ToList().ForEach(t =>
      {
        Assert.IsNotNull(t.Name);
      });
    }

  }
}
