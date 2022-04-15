using System;
using System.Threading.Tasks;
using IkeMtz.AdventureWorks.Data;
using IkeMtz.AdventureWorks.Models;
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
  public class ProductsController : ControllerBase
  {
    private readonly DatabaseContext _databaseContext;
    public ProductsController(DatabaseContext databaseContext)
    {
      _databaseContext = databaseContext;
    }

    // Get api/Items
    [HttpGet]
    [ProducesResponseType(Status200OK, Type = typeof(Product))]
    public async Task<ActionResult> Get([FromQuery] Guid id)
    {
      var obj = await _databaseContext.Products
        .AsNoTracking()
        .FirstOrDefaultAsync(t => t.Id == id)
        .ConfigureAwait(false);
      return Ok(obj);
    }

    // Post api/Items
    [HttpPost]
    [ProducesResponseType(Status200OK, Type = typeof(Product))]
    [ValidateModel]
    public async Task<ActionResult> Post([FromBody] Product value)
    {
      var dbContextObject = _databaseContext.Products.Add(value);
      _ = await _databaseContext.SaveChangesAsync()
          .ConfigureAwait(false);
      return Ok(dbContextObject.Entity);
    }

    // Put api/Items
    [HttpPut]
    [ProducesResponseType(Status200OK, Type = typeof(Product))]
    [ValidateModel]
    public async Task<ActionResult> Put([FromQuery] Guid id, [FromBody] Product value)
    {
      var obj = await _databaseContext.Products.FirstOrDefaultAsync(t => t.Id == id)
        .ConfigureAwait(false);
      SimpleMapper<Product>.Instance.ApplyChanges(value, obj);
      _ = await _databaseContext.SaveChangesAsync()
          .ConfigureAwait(false);
      return Ok(obj);
    }

    // Put api/Items
    [HttpDelete]
    [ProducesResponseType(Status200OK, Type = typeof(Product))]
    public async Task<ActionResult> Delete([FromQuery] Guid id)
    {
      var obj = await _databaseContext.Products.FirstOrDefaultAsync(t => t.Id == id)
        .ConfigureAwait(false);
      _ = _databaseContext.Remove(obj);
      _ = await _databaseContext.SaveChangesAsync()
          .ConfigureAwait(false);
      return Ok(obj);
    }
  }
}
