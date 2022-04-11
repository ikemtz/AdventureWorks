using System;
using System.Collections.Generic;
using IkeMtz.AdventureWorks.Data;
using IkeMtz.AdventureWorks.Models;
using IkeMtz.NRSRx.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IkeMtz.AdventureWorks.OData.Controllers.V1
{
  [ApiVersion(VersionDefinitions.v1_0)]
  [Authorize]
  [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 6000)]
  public class CustomersController : ODataController
  {
    private readonly DatabaseContext _databaseContext;

    public CustomersController(DatabaseContext databaseContext)
    {
      _databaseContext = databaseContext;
    }

    [Produces("application/json")]
    [ProducesResponseType(typeof(ODataEnvelope<Customer, Guid>), Status200OK)]
    [EnableQuery(MaxTop = 100, AllowedQueryOptions = AllowedQueryOptions.All)]
    public IEnumerable<Customer> Get()
    {
      return _databaseContext.Customers
        .AsNoTracking();
    }
  }
}
