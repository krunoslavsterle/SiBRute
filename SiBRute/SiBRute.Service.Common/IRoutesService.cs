using SiBRute.Model;
using SiBRute.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiBRute.Service.Common
{
    public interface IRoutesService : IDisposable
    {

        #region Methods
        
        /// <summary>
        /// Add or update route in repository asynchronously
        /// </summary>
        /// <param name="route">The route object</param>
        /// <returns></returns>
        Task<int> AddRouteAsync(BikeRoute route);

        /// <summary>
        /// Remove route from repositroy asynchronously
        /// </summary>
        /// <param name="routeId">The route indentifier</param>
        /// <returns></returns>
        Task<int> RemoveRouteAsync(int routeId);
                
        /// <summary>
        /// Gets specific route by provided route identifier asynchronously
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        Task<BikeRoute> GetRouteAsync(int routeId);
        
        /// <summary>
        /// Gets all the routes asynchronously
        /// </summary>
        /// <returns></returns>
        Task<List<BikeRoute>> GetAllRoutesAsync();

        /// <summary>
        /// Gets all routes that dont have greater distance than param asynchronously
        /// </summary>
        /// <param name="maxDistance">Max distance of the route</param>
        /// <returns></returns>
        Task<List<BikeRoute>> GetRoutesWithMaxDistanceAsync(int maxDistance);

        /// <summary>
        /// Gets all routes that are near designated place asynchronously
        /// </summary>
        /// <param name="place">Name of the place on the route</param>
        /// <returns></returns>
        Task<List<BikeRoute>> GetRoutesNearPlaceAsync(string place);

        #endregion Methods

    }
}
