using System;
using System.Threading.Tasks;
using IkeMtz.AdventureWorks.Models;
using IkeMtz.AdventureWorks.WebApi.Data;
using IkeMtz.NRSRx.Core.Models;
using IkeMtz.NRSRx.Core.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IkeMtz.AdventureWorks.WebApi.Controllers.V1
{
  [Route("api/v{version:apiVersion}/[controller].{format}"), FormatFilter]
  [ApiVersion(VersionDefinitions.v1_0)]
  [ApiController]
  public class AddressesController : ControllerBase
  {
    private readonly DatabaseContext _databaseContext;
    public AddressesController(DatabaseContext databaseContext)
    {
      _databaseContext = databaseContext;
    }

    // Get api/Items
    [HttpGet]
    [ProducesResponseType(Status200OK, Type = typeof(Address))]
    public async Task<ActionResult> Get([FromQuery] Guid id)
    {
      var obj = await _databaseContext.Addresses
        .AsNoTracking()
        .FirstOrDefaultAsync(t => t.Id == id)
        .ConfigureAwait(false);
      return Ok(obj);
    }

    // Post api/Items
    [HttpPost]
    [ProducesResponseType(Status200OK, Type = typeof(Address))]
    [ValidateModel]
    public async Task<ActionResult> Post([FromBody] Address value)
    {
      var dbContextObject = _databaseContext.Addresses.Add(value);
      _ = await _databaseContext.SaveChangesAsync()
          .ConfigureAwait(false);
      return Ok(dbContextObject.Entity);
    }

    // Put api/Items
    [HttpPut]
    [ProducesResponseType(Status200OK, Type = typeof(Address))]
    [ValidateModel]
    public async Task<ActionResult> Put([FromQuery] Guid id, [FromBody] Address value)
    {
      var obj = await _databaseContext.Addresses.FirstOrDefaultAsync(t => t.Id == id)
        .ConfigureAwait(false);
      SimpleMapper<Address>.Instance.ApplyChanges(value, obj);
      _ = await _databaseContext.SaveChangesAsync()
          .ConfigureAwait(false);
      return Ok(obj);
    }

    // Put api/Items
    [HttpDelete]
    [ProducesResponseType(Status200OK, Type = typeof(Address))]
    public async Task<ActionResult> Delete([FromQuery] Guid id)
    {
      var obj = await _databaseContext.Addresses.FirstOrDefaultAsync(t => t.Id == id)
        .ConfigureAwait(false);
      _ = _databaseContext.Remove(obj);
      _ = await _databaseContext.SaveChangesAsync()
          .ConfigureAwait(false);
      return Ok(obj);
    }
  }
}
