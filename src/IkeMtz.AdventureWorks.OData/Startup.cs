using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using IkeMtz.AdventureWorks.Data;
using IkeMtz.AdventureWorks.Models;
using IkeMtz.AdventureWorks.OData.Configuration;
using IkeMtz.NRSRx.Core.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IkeMtz.AdventureWorks.OData
{
  public class Startup : CoreODataStartup
  {
    public override string MicroServiceTitle => $"{nameof(AdventureWorks)} OData Microservice";
    public override Assembly StartupAssembly => typeof(Startup).Assembly;
    public override bool IncludeXmlCommentsInSwaggerDocs => true;
    public override string[] AdditionalAssemblyXmlDocumentFiles => new[] {
      typeof(Product).Assembly.Location.Replace(".dll", ".xml", StringComparison.InvariantCultureIgnoreCase)
    };

    public override BaseODataModelProvider ODataModelProvider => new ODataModelProvider();

    public Startup(IConfiguration configuration) : base(configuration)
    {
    }
    [ExcludeFromCodeCoverage]
    public override void SetupDatabase(IServiceCollection services, string dbConnectionString)
    {
      _ = services
       .AddDbContextPool<DatabaseContext>(x => x.UseSqlServer(dbConnectionString, options => options.EnableRetryOnFailure()))
       .AddEntityFrameworkSqlServer();
    }
  }
}
