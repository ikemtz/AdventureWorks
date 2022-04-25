using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IkeMtz.NRSRx.Core.Models;

namespace IkeMtz.AdventureWorks.Models
{
  public partial class SalesAgent : IIdentifiable<int>
  {
    public SalesAgent()
    {
      Customers = new HashSet<Customer>();
    }

    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(256)]
    public string Name { get; set; }
    [Required]
    [MaxLength(256)]
    public string LoginId { get; set; }
    public virtual ICollection<Customer> Customers { get; }
  }
}
