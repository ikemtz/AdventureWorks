using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IkeMtz.AdventureWorks.Models
{
  public class OrderAddress: IkeMtz.NRSRx.Core.Models.IIdentifiable, IkeMtz.NRSRx.Core.Models.IAuditable
  {
    public OrderAddress()
    {
      Orders = new HashSet<Order>();
    }

    [Required]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(60)]
    public string Line1 { get; set; }
    [MaxLength(60)]
    public string Line2 { get; set; }
    [Required]
    [MaxLength(100)]
    public string City { get; set; }
    [Required]
    [MaxLength(50)]
    public string StateProvince { get; set; }
    [Required]
    [MaxLength(50)]
    public string CountryRegion { get; set; }
    [Required]
    [MaxLength(15)]
    public string PostalCode { get; set; }
    [Required]
    [MaxLength(320)]
    public string CreatedBy { get; set; }
    [Required]
    public DateTimeOffset CreatedOnUtc { get; set; }
    [MaxLength(320)]
    public string UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedOnUtc { get; set; }
    public virtual ICollection<Order> Orders { get; }
  }

}
