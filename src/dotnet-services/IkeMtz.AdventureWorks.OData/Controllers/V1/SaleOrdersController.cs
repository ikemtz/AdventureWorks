﻿using System;
using System.Collections.Generic;
using IkeMtz.AdventureWorks.Models;
using IkeMtz.AdventureWorks.OData.Data;
using IkeMtz.NRSRx.Core.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNet.OData.Query.AllowedQueryOptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IkeMtz.AdventureWorks.OData.Controllers.V1
{
  [ApiVersion(VersionDefinitions.v1_0)]
  [Authorize]
  [ODataRoutePrefix("SaleOrders")]
  [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 6000)]
  public class SaleOrdersController : ODataController
  {
    private readonly DatabaseContext _databaseContext;

    public SaleOrdersController(DatabaseContext databaseContext)
    {
      _databaseContext = databaseContext;
    }

    [ODataRoute]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ODataEnvelope<SaleOrder, Guid>), Status200OK)]
    [EnableQuery(MaxTop = 100, AllowedQueryOptions = All)]
    public IEnumerable<SaleOrder> Get()
    {
      return _databaseContext.SaleOrders
        .AsNoTracking();
    }
  }
}
