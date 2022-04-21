using System;
using System.Threading.Tasks;
using IkeMtz.AdventureWorks.Data;
using IkeMtz.AdventureWorks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IkeMtz.AdventureWorks.WebApi.Controllers.V1
{
  [Route("api/v{version:apiVersion}/[controller].{format}"), FormatFilter]
  [ApiVersion(VersionDefinitions.v1_0)]
  [ApiController]
  public class OrderLineItemsController : ControllerBase
  {
    private readonly DatabaseContext _databaseContext;
    public OrderLineItemsController(DatabaseContext databaseContext)
    {
      _databaseContext = databaseContext;
    }
     
    // Put api/Items
    [HttpDelete]
    [ProducesResponseType(Status200OK, Type = typeof(Order))]
    public async Task<ActionResult> Delete([FromQuery] Guid id)
    {
      var obj = await _databaseContext.OrderLineItems.FirstOrDefaultAsync(t => t.Id == id)
        .ConfigureAwait(false);
      if (obj == null)
      {
        return Conflict($"OrderLineItem Id {id} is not found");
      }
      else
      {
        _ = _databaseContext.Remove(obj);
        _ = await _databaseContext.SaveChangesAsync()
            .ConfigureAwait(false);
        return Ok(obj);
      }
    }
  }
}
