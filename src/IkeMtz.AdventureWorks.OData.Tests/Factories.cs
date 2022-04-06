using IkeMtz.AdventureWorks.Models;
using static IkeMtz.NRSRx.Core.Unigration.TestDataFactory;

namespace IkeMtz.AdventureWorks.Tests
{
  public static partial class Factories
  {
    public static Client ClientFactory()
    {
      var client = CreateIdentifiable(CreateAuditable<Client>());
      client.Name = StringGenerator(15, allowSpaces: true);
      client.CompanyName = StringGenerator(30, allowSpaces: true);
      client.EmailAddress = $"{StringGenerator(5)}@{StringGenerator(10)}.com";
      client.SalesPerson = StringGenerator(35, allowSpaces: true);
      return client;
    }
    public static Order OrderFactory(Client client)
    {
      var order = CreateIdentifiable(CreateAuditable<Order>());
      order.Client = client;
      client.Orders.Add(order);
      order.PurchaseOrderNum = StringGenerator(20);
      order.Status = 1;
      return order;
    }
  }
}
