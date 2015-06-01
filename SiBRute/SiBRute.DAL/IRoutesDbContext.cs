using SiBRute.Model;
using System.Data.Entity;

namespace SiBRute.DAL
{
    public interface IRoutesDbContext
    {
        DbSet<BikeRoute> Routes { get; set; }   
    }
}
