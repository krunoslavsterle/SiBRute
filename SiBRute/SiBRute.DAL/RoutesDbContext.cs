using SiBRute.Model;
using System.Data.Entity;

namespace SiBRute.DAL
{
    public class RoutesDbContext : DbContext, IRoutesDbContext
    {
        public DbSet<BikeRoute> Routes { get; set; }       
    }
}
