using SiBRute.Model.Common;
using System.Collections.Generic;

namespace SiBRute.Repository.Common
{
    public interface IRoutesRepository
    {
        /// <summary>
        /// Gets all routes
        /// </summary>
        /// <returns></returns>
        IEnumerable<IBikeRoute> GetAllRoutes();
    }
}
