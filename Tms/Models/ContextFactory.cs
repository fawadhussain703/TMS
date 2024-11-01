using System.Configuration;
using System.Data.Entity;

namespace Tms.Models
{
    public class ContextFactory
    {
        public static ApplicationDbContext CreateDbContext()
        {
            
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var context = new ApplicationDbContext();
            context.Database.Connection.ConnectionString = connectionString;

            return context;
        }
    }
}
