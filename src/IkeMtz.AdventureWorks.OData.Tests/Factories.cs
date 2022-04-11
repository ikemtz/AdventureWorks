using System;
using IkeMtz.AdventureWorks.Models;
using IkeMtz.NRSRx.Core.Unigration;
using static IkeMtz.NRSRx.Core.Unigration.TestDataFactory;

namespace IkeMtz.AdventureWorks.Tests
{
  public static partial class Factories
  {
    public static Customer CustomerFactory()
    {
      var Customer = CreateIdentifiable(CreateAuditable<Customer>());
      Customer.Name = StringGenerator(15, allowSpaces: true);
      Customer.Num = $"10-4000-{StringGenerator(6, characterSet: CharacterSets.Numeric)}";
      Customer.CompanyName = StringGenerator(30, allowSpaces: true);
      Customer.EmailAddress = $"{StringGenerator(5)}@{StringGenerator(10)}.com";
      Customer.SalesPerson = StringGenerator(35, allowSpaces: true);
      return Customer;
    }

    public static Order OrderFactory(Customer Customer = null)
    {
      var order = CreateIdentifiable(CreateAuditable<Order>());
      order.Customer = Customer ?? CustomerFactory();
      order.Customer.Orders.Add(order);
      order.ShipMethod = "CARGO TRANSPORT 5";
      order.PurchaseOrderNum = StringGenerator(20);
      order.Num = StringGenerator(7, characterSet: CharacterSets.UpperCase + CharacterSets.Numeric);
      order.Status = 1;
      return order;
    }
  }
}
