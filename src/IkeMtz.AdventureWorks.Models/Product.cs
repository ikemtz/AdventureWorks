﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IkeMtz.AdventureWorks.Models
{
  // Generated by the SQL POCO Class Generator Script
  // Script is available at:
  // https://raw.githubusercontent.com/ikemtz/NRSRx/master/tools/sql-poco-class-generator.sql

  public partial class Product
  : IkeMtz.NRSRx.Core.Models.IIdentifiable, IkeMtz.NRSRx.Core.Models.IAuditable
  {

    public Product()
    {
      OrderLineItems = new HashSet<OrderLineItem>();
    }

    [Required]
    public Guid Id { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MinLength(10)]
    [MaxLength(25)]
    public string Num { get; set; }
    [MinLength(3)]
    [MaxLength(15)]
    public string Color { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal StandardCost { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal ListPrice { get; set; }
    [MaxLength(5)]
    public string Size { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal? Weight { get; set; }
    public Guid? ProductCategoryId { get; set; }
    public Guid? ProductModelId { get; set; }
    [Required]
    public DateTime SellStartDate { get; set; }
    public DateTime? SellEndDate { get; set; }
    public DateTime? DiscontinuedDate { get; set; }
    [MaxLength(5000)]
    public byte[] ThumbNailPhoto { get; set; }
    [Required]
    [MaxLength(320)]
    public string CreatedBy { get; set; }
    [Required]
    public DateTimeOffset CreatedOnUtc { get; set; }
    [MaxLength(320)]
    public string UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedOnUtc { get; set; }
    public virtual ProductModel ProductModel { get; set; }
    public virtual ProductCategory ProductCategory { get; set; }
    public virtual ICollection<OrderLineItem> OrderLineItems { get; }
  }
}
