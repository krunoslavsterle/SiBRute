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

        /// <summary>
        /// Add or update route in repository
        /// </summary>
        /// <param name="route">The route object</param>
        /// <returns></returns>
        bool AddRoute(IBikeRoute route);

        /// <summary>
        /// Remove route from repositroy
        /// </summary>
        /// <param name="routeId">The route indentifier</param>
        /// <returns></returns>
        bool RemoveRoute(int routeId);
    }
}
