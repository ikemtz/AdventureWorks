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
  public partial class ClientsTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Unigration")]
    public async Task SaveClientsTest()
    {
      var item = Factories.ClientFactory();
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationWebApiTestStartup>());
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.PostAsJsonAsync($"api/v1/{nameof(Client)}s.json", item);
      _ = resp.EnsureSuccessStatusCode();
      var httpClient = await DeserializeResponseAsync<Client>(resp);
      Assert.AreEqual("IntegrationTester@email.com", httpClient.CreatedBy);

      var dbContext = srv.GetDbContext<DatabaseContext>();
      var dbClient = await dbContext.Clients.FirstOrDefaultAsync(t => t.Id == item.Id);

      Assert.IsNotNull(dbClient);
      Assert.AreEqual(httpClient.CreatedOnUtc, dbClient.CreatedOnUtc);
    }


    [TestMethod]
    [TestCategory("Unigration")]
    public async Task UpdateClientTest()
    {
      var originalClient = Factories.ClientFactory();
      originalClient.CreatedBy = "blah";
      originalClient.CreatedOnUtc = DateTime.UtcNow;
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationWebApiTestStartup>()
        .ConfigureTestServices(x =>
        {
          ExecuteOnContext<DatabaseContext>(x, db =>
          {
            _ = db.Clients.Add(originalClient);
          });
        }));
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var updatedClient = JsonConvert.DeserializeObject<Client>(JsonConvert.SerializeObject(originalClient));
      updatedClient.Name = TestDataFactory.StringGenerator(6);

      var resp = await client.PutAsJsonAsync($"api/v1/{nameof(Client)}s.json?id={updatedClient.Id}", updatedClient);
      _ = resp.EnsureSuccessStatusCode();
      var httpUpdatedClient = await DeserializeResponseAsync<Client>(resp);
      Assert.AreEqual("IntegrationTester@email.com", httpUpdatedClient.UpdatedBy);
      Assert.AreEqual(updatedClient.Name, httpUpdatedClient.Name);
      Assert.IsNull(updatedClient.UpdatedOnUtc);
      Assert.IsNotNull(httpUpdatedClient.UpdatedOnUtc);

      var dbContext = srv.GetDbContext<DatabaseContext>();
      var updatedDbClient = await dbContext.Clients.FirstOrDefaultAsync(t => t.Id == originalClient.Id);

      Assert.IsNotNull(updatedDbClient);
      Assert.IsNotNull(updatedDbClient.UpdatedOnUtc);
      Assert.AreEqual(httpUpdatedClient.UpdatedOnUtc, updatedDbClient.UpdatedOnUtc);
    }

  }
}
