﻿using System;
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
  public partial class CustomersTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Unigration")]
    public async Task SaveCustomersTest()
    {
      var item = Factories.CustomerFactory();
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationWebApiTestStartup>());
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.PostAsJsonAsync($"api/v1/{nameof(Customer)}s.json", item);
      _ = resp.EnsureSuccessStatusCode();
      var httpCustomer = await DeserializeResponseAsync<Customer>(resp);
      Assert.AreEqual("IntegrationTester@email.com", httpCustomer.CreatedBy);

      var dbContext = srv.GetDbContext<DatabaseContext>();
      var dbCustomer = await dbContext.Customers.FirstOrDefaultAsync(t => t.Id == item.Id);

      Assert.IsNotNull(dbCustomer);
      Assert.AreEqual(httpCustomer.CreatedOnUtc, dbCustomer.CreatedOnUtc);
    }


    [TestMethod]
    [TestCategory("Unigration")]
    public async Task UpdateCustomerTest()
    {
      var originalCustomer = Factories.CustomerFactory();
      originalCustomer.CreatedBy = "blah";
      originalCustomer.CreatedOnUtc = DateTime.UtcNow;
      using var srv = new TestServer(TestHostBuilder<Startup, UnigrationWebApiTestStartup>()
        .ConfigureTestServices(x =>
        {
          ExecuteOnContext<DatabaseContext>(x, db =>
          {
            _ = db.Customers.Add(originalCustomer);
          });
        }));
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var updatedCustomer = JsonClone(originalCustomer);
      updatedCustomer.Name = TestDataFactory.StringGenerator(6);

      var resp = await client.PutAsJsonAsync($"api/v1/{nameof(Customer)}s.json?id={updatedCustomer.Id}", updatedCustomer);
      _ = resp.EnsureSuccessStatusCode();
      var httpUpdatedCustomer = await DeserializeResponseAsync<Customer>(resp);
      Assert.AreEqual("IntegrationTester@email.com", httpUpdatedCustomer.UpdatedBy);
      Assert.AreEqual(updatedCustomer.Name, httpUpdatedCustomer.Name);
      Assert.IsNull(updatedCustomer.UpdatedOnUtc);
      Assert.IsNotNull(httpUpdatedCustomer.UpdatedOnUtc);

      var dbContext = srv.GetDbContext<DatabaseContext>();
      var updatedDbCustomer = await dbContext.Customers.FirstOrDefaultAsync(t => t.Id == originalCustomer.Id);

      Assert.IsNotNull(updatedDbCustomer);
      Assert.IsNotNull(updatedDbCustomer.UpdatedOnUtc);
      Assert.AreEqual(httpUpdatedCustomer.UpdatedOnUtc, updatedDbCustomer.UpdatedOnUtc);
    }

  }
}
