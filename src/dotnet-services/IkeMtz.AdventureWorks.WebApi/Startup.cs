using IkeMtz.AdventureWorks.WebApi.Data;
using IkeMtz.NRSRx.Core.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IkeMtz.AdventureWorks.WebApi
{
  public class Startup : CoreWebApiStartup
  {
    public override string MicroServiceTitle => $"{nameof(IkeMtz.AdventureWorks.WebApi)} WebApi Microservice";
    public override Assembly StartupAssembly => typeof(Startup).Assembly;

    public Startup(IConfiguration configuration) : base(configuration) { }

    public override void SetupDatabase(IServiceCollection services, string dbConnectionString)
    {
      _ = services
      .AddDbContext<DatabaseContext>(x => x.UseSqlServer(dbConnectionString))
      .AddEntityFrameworkSqlServer();
    }
  }
}
