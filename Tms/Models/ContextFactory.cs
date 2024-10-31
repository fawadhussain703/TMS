using System.Data.Entity;

namespace Tms.Models
{
    public class ContextFactory
    {
        public static ApplicationDbContext CreateDbContext()
        {
            var connectionString = "Data Source=51.38.41.235;Initial Catalog=TSM.Documents;Integrated Security=False;Persist Security Info=True;User ID=DOTNET;Password=sql#@int123";

            var context = new ApplicationDbContext();
            context.Database.Connection.ConnectionString = connectionString;

            return context;
        }
    }
}
