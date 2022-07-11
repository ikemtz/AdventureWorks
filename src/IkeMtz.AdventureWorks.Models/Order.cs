﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IkeMtz.AdventureWorks.Models
{
  // Generated by the SQL POCO Class Generator Script
  // Script is available at:
  // https://raw.githubusercontent.com/ikemtz/NRSRx/master/tools/sql-poco-class-generator.sql

  public partial class Order
  : IkeMtz.NRSRx.Core.Models.IIdentifiable, IkeMtz.NRSRx.Core.Models.IAuditable
  {
    public Order()
    {
      OrderLineItems = new HashSet<OrderLineItem>();
    }

    [Required]
    [Key]
    public Guid Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public byte RevisionNum { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    public DateTime? ShipDate { get; set; }
    [Required]
    public OrderStatusTypes Status { get; set; }
    [Required]
    public bool IsOnlineOrder { get; set; }
    [Required]
    [MaxLength(25)]
    public string Num { get; set; }
    [MaxLength(25)]
    public string PurchaseOrderNum { get; set; } 
    [Required]
    public Guid CustomerId { get; set; }
    public Guid? ShipToAddressId { get; set; }
    public Guid? BillToAddressId { get; set; }
    [Required]
    public ShippingTypes ShippingType { get; set; }
    [MaxLength(15)]
    public string CreditCardApprovalCode { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal SubTotal { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal TaxAmt { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal Freight { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal TotalDue { get; set; }
    [MaxLength(500)]
    public string Comment { get; set; }
    [Required]
    [MaxLength(320)]
    public string CreatedBy { get; set; }
    [Required]
    public DateTimeOffset CreatedOnUtc { get; set; }
    [MaxLength(320)]
    public string UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedOnUtc { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual OrderAddress ShipToAddress { get; set; }
    public virtual OrderAddress BillToAddress { get; set; }
    public virtual ICollection<OrderLineItem> OrderLineItems { get; }
  }
}
