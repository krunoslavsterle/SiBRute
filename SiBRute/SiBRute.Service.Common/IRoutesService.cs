using SiBRute.Model.Common;
using System.Collections.Generic;

namespace SiBRute.Service.Common
{
    public interface IRoutesService
    {

        #region Methods

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

        /// <summary>
        /// Gets specific route by provided route identifier
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        IBikeRoute GetRoute(int routeId);

        /// <summary>
        /// Gets all routes from repository
        /// </summary>
        /// <returns></returns>
        IEnumerable<IBikeRoute> GetAllRoutes();

        /// <summary>
        /// Gets all routes that dont have greater distance than param
        /// </summary>
        /// <param name="maxDistance">Max distance of the route</param>
        /// <returns></returns>
        IEnumerable<IBikeRoute> GetRoutesWithMaxDistance(int maxDistance);

        /// <summary>
        /// Gets all routes that are near designated place
        /// </summary>
        /// <param name="place">Name of the place on the route</param>
        /// <returns></returns>
        IEnumerable<IBikeRoute> GetRoutesNearPlace(string place);

        #endregion Methods

    }
}
