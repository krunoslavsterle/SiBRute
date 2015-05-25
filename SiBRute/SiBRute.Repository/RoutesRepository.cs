using SiBRute.DAL;
using SiBRute.Repository.Common;
using System.Collections.Generic;

namespace SiBRute.Repository
{
    public class RoutesRepository : IRoutesRepository
    {
        private RoutesDbContext context = new RoutesDbContext();        
        
        public IEnumerable<Model.Common.IBikeRoute> GetAllRoutes()
        {           
            return context.Routes;           
        }
    }
}
