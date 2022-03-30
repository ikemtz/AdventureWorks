﻿using System;
using System.ComponentModel.DataAnnotations;
using IkeMtz.NRSRx.Core.Models.Validation;

namespace IkeMtz.AdventureWorks.Models
{
  // Generated by the SQL POCO Class Generator Script
  // Script is available at:
  // https://raw.githubusercontent.com/ikemtz/NRSRx/master/tools/sql-poco-class-generator.sql

  public partial class OrderLineItem
  : IkeMtz.NRSRx.Core.Models.IIdentifiable, IkeMtz.NRSRx.Core.Models.IAuditable
  {
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid OrderId { get; set; }
    [Required]
    public Int16 OrderQty { get; set; }
    [Required]
    public Guid ProductId { get; set; }
    [Required]
    public decimal UnitPrice { get; set; }
    [Required]
    public decimal UnitPriceDiscount { get; set; }
    [Required]
    public decimal LineTotal { get; set; }
    [Required]
    [MaxLength(320)]
    public string CreatedBy { get; set; }
    [Required]
    public DateTimeOffset CreatedOnUtc { get; set; }
    [MaxLength(320)]
    public string UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedOnUtc { get; set; }
    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }
  }
}