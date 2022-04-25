using System;
using IkeMtz.AdventureWorks.Models;
using IkeMtz.NRSRx.Core.Unigration;
using static IkeMtz.NRSRx.Core.Unigration.TestDataFactory;

namespace IkeMtz.AdventureWorks.Tests
{
  public static partial class Factories
  {
    static readonly Random Random;
    static Factories()
    {
      Random = new Random(DateTime.Now.Millisecond);
    }
    public static SalesAgent SalesAgentFactory()
    {
      return new SalesAgent()
      {
        Name = StringGenerator(15, allowSpaces: true),
        LoginId = $"adventure-works/{StringGenerator(15, allowSpaces: true)}",
      };
    }
    public static Customer CustomerFactory(SalesAgent salesAgent = null)
    {
      var Customer = CreateIdentifiable(CreateAuditable<Customer>());
      Customer.Name = StringGenerator(15, allowSpaces: true);
      Customer.Num = $"10-4000-{StringGenerator(6, characterSet: CharacterSets.Numeric)}";
      Customer.CompanyName = StringGenerator(30, allowSpaces: true);
      Customer.EmailAddress = $"{StringGenerator(5)}@{StringGenerator(10)}.com";
      Customer.SalesAgent = salesAgent ?? SalesAgentFactory();
      return Customer;
    }

    public static Order OrderFactory(Customer customer = null)
    {
      var order = CreateIdentifiable(CreateAuditable<Order>());
      order.Customer = customer ?? CustomerFactory();
      order.ShipMethod = "CARGO TRANSPORT 5";
      order.PurchaseOrderNum = StringGenerator(20);
      order.Num = StringGenerator(7, characterSet: CharacterSets.UpperCase + CharacterSets.Numeric);
      order.Status = 1;
      return order;
    }

    public static OrderLineItem OrderLineItemFactory(Order order = null, Product product = null)
    {
      order ??= OrderFactory(); 
      var lineItem = CreateIdentifiable(CreateAuditable<OrderLineItem>());

      lineItem.OrderQty = Convert.ToInt16(Random.Next(1, 20));
      lineItem.UnitPrice = Random.Next(2, 1000);
      lineItem.Product = product ?? ProductFactory();

      if (!order.OrderLineItems.Contains(lineItem))
      {
        order.OrderLineItems.Add(lineItem);
      }
      return lineItem;
    }

    public static Product ProductFactory()
    {
      var product = CreateIdentifiable(CreateAuditable<Product>());
      product.Name = StringGenerator(20, characterSet: CharacterSets.UpperCase + CharacterSets.LowerCase);
      product.Num = StringGenerator(20);
      return product;
    }

    public static OrderAddress OrderAddressFactory()
    {
      var orderAddress = CreateIdentifiable(CreateAuditable<OrderAddress>());
      orderAddress.Line1 = StringGenerator(20, characterSet: CharacterSets.UpperCase + CharacterSets.LowerCase + CharacterSets.Numeric);
      orderAddress.City = StringGenerator(20);
      orderAddress.StateProvince = StringGenerator(2, false, characterSet: CharacterSets.UpperCase);
      orderAddress.CountryRegion = StringGenerator(3, characterSet: CharacterSets.UpperCase);
      orderAddress.PostalCode = StringGenerator(5, characterSet: CharacterSets.Numeric);
      return orderAddress;
    }
  }
}
