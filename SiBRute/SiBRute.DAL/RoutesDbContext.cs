using SiBRute.Model;
using System.Data.Entity;

namespace SiBRute.DAL
{
    public class RoutesDbContext : DbContext
    {
        public DbSet<BikeRoute> Routes { get; set; }       
    }
}
