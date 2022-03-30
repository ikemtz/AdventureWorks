using Microsoft.EntityFrameworkCore;

namespace IkeMtz.AdventureWorks.Data
{
  public partial class DatabaseContext : DbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
  }
}
