using SiBRute.Model;
using SiBRute.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
        /// Gets all the routes asynchronously
        /// </summary>
        /// <returns></returns>
        Task<List<BikeRoute>> GetAllRoutesAsync();

        /// <summary>
        /// Finde the specific route
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        Task<BikeRoute> FindAsync(int routeId);

        /// <summary>
        /// Add or update route in repository
        /// </summary>
        /// <param name="route">The route object</param>
        /// <returns></returns>
        bool AddRoute(IBikeRoute route);

        /// <summary>
        /// Add or update route in repository asynchronously
        /// </summary>
        /// <param name="route">The route object</param>
        /// <returns></returns>
        Task<bool> AddRouteAsync(BikeRoute route);

        /// <summary>
        /// Remove route from repositroy
        /// </summary>
        /// <param name="routeId">The route indentifier</param>
        /// <returns></returns>
        bool RemoveRoute(int routeId);
    }
}
