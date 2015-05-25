using SiBRute.DAL.Entities;
using System.Data.Entity;

namespace SiBRute.DAL
{
    public class RoutesDbContext : DbContext
    {
        public DbSet<BikeRouteEntity> Routes { get; set; }
    }
}
