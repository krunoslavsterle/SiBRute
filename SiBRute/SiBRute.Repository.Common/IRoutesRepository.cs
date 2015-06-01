using SiBRute.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SiBRute.Repository.Common
{
    public interface IRoutesRepository : IDisposable
    {        
        /// <summary>
        /// Gets all the routes asynchronously
        /// </summary>
        /// <returns></returns>
        Task<List<BikeRoute>> GetAllAsync(Expression<Func<BikeRoute, bool>> predicate = null);

        /// <summary>
        /// Finde the specific route
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        Task<BikeRoute> GetAsync(Expression<Func<BikeRoute, bool>> predicate);

        /// <summary>
        /// Add or update route in repository asynchronously
        /// </summary>
        /// <param name="route">The route object</param>
        /// <returns></returns>
        Task<int> AddRouteAsync(BikeRoute route);

        /// <summary>
        /// Update the route in repository asynchronously
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        Task<int> UpdateRouteAsync(BikeRoute route);

        /// <summary>
        /// Remove route from repositroy
        /// </summary>
        /// <param name="routeId">The route indentifier</param>
        /// <returns></returns>
        Task<int> RemoveRouteAsync(int routeId);
    }
}
