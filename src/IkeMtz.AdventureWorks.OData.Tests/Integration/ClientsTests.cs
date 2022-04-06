using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IkeMtz.NRSRx.Core.Models;
using IkeMtz.NRSRx.Core.Unigration;
using IkeMtz.AdventureWorks.Models;
using IkeMtz.AdventureWorks.OData;
using IkeMtz.AdventureWorks.Tests;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using IkeMtz.AdventureWorks.Data;

namespace IkeMtz.AdventureWorks.OData.Tests.Integration
{
  [TestClass]
  public partial class ClientsTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Integration")]
    [TestCategory("SqlIntegration")]
    public async Task GetClientsTest()
    {
      using var srv = new TestServer(TestHostBuilder<Startup, IntegrationODataTestStartup>());
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.GetStringAsync($"odata/v1/{nameof(Client)}s?$count=true");
      TestContext.WriteLine($"Server Reponse: {resp}");
      var envelope = JsonConvert.DeserializeObject<ODataEnvelope<Client>>(resp);
      Assert.AreEqual(envelope.Count, envelope.Value.Count());
      envelope.Value.ToList().ForEach(t =>
      {
        Assert.IsNotNull(t.Name);
        Assert.AreNotEqual(Guid.Empty, t.Id);
      });
    }

    [TestMethod]
    [TestCategory("Integration")]
    [TestCategory("SqlIntegration")]
    public async Task GetGroupByClientsTest()
    {
      var Client = Factories.ClientFactory();
      using var srv = new TestServer(TestHostBuilder<Startup, IntegrationODataTestStartup>()
          .ConfigureTestServices(x =>
          {
            ExecuteOnContext<DatabaseContext>(x, db =>
            {
              _ = db.Clients.Add(Client);
            });
          })
       );
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());
      HttpResponseMessage resp = null;
      try
      {
        resp = await client.GetAsync($"odata/v1/{nameof(Client)}s?$apply=groupby(({nameof(Client.Name)},{nameof(Client.EmailAddress)}))");
      }
      catch (Exception) { }
      var body = await resp.Content.ReadAsStringAsync();
      TestContext.WriteLine($"Server Reponse: {body}");
      Assert.IsFalse(body.ToLower().Contains("updatedby"));
      StringAssert.Contains(body, Client.Name);
    }

  }
}
