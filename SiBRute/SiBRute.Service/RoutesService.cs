using SiBRute.Service.Common;
using System.Collections.Generic;
using System.Linq;
using SiBRute.Repository.Common;
using SiBRute.Model.Common;
using System;
using System.Threading.Tasks;
using SiBRute.Model;

namespace SiBRute.Service
{
    public class RoutesService : IRoutesService
    {
        #region Properties

        protected IRoutesRepository repository { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialize a new instance of the <see cref="RoutesService"/> class.
        /// </summary>
        /// <param name="repository"></param>
        public RoutesService(IRoutesRepository repository)
        {            
            this.repository = repository;
        }

       

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Add or update route in repository
        /// </summary>
        /// <param name="route">The route object</param>
        /// <returns></returns>
        public bool AddRoute(IBikeRoute route)
        {            
            route.DateCreated = DateTime.Now;
            return repository.AddRoute(route);
        }

        /// <summary>
        /// Add or update route in repository asynchronously
        /// </summary>
        /// <param name="route">The route object</param>
        /// <returns></returns>
        public async Task<bool> AddRouteAsync(BikeRoute route)
        {
            route.DateCreated = DateTime.Now;
            return await repository.AddRouteAsync(route);
        }

        /// <summary>
        /// Remove route from repositroy
        /// </summary>
        /// <param name="routeId">The route indentifier</param>
        /// <returns></returns>
        public bool RemoveRoute(int routeId)
        {
            return repository.RemoveRoute(routeId);
        }

        /// <summary>
        /// Gets specific route by provided route identifier
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public IBikeRoute GetRoute(int routeId)
        {
            return repository.GetAllRoutes().FirstOrDefault(r => r.Id == routeId);
        }

        /// <summary>
        /// Gets specific route by provided route identifier asynchronously
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public async Task<BikeRoute> GetRouteAsync(int routeId)
        {
            return await repository.FindAsync(routeId);
        }

        /// <summary>
        /// Gets all the routes from repository
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBikeRoute> GetAllRoutes()
        {
            return repository.GetAllRoutes();
        }

        /// <summary>
        /// Gets all the routes from repository asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<List<BikeRoute>> GetAllRoutesAsync()
        {
            return await repository.GetAllRoutesAsync();
        }

        /// <summary>
        /// Gets all routes that dont have greater distance than param
        /// </summary>
        /// <param name="maxDistance">Max distance of the route</param>
        /// <returns></returns>
        public IEnumerable<IBikeRoute> GetRoutesWithMaxDistance(int maxDistance)
        {            
            return repository.GetAllRoutes().Where(r => (r.Distance <= maxDistance));
        }

        /// <summary>
        /// Gets all routes that are near designated place
        /// </summary>
        /// <param name="place">Name of the place on the route</param>
        /// <returns></returns>
        public IEnumerable<IBikeRoute> GetRoutesNearPlace(string place)
        {            
            return repository.GetAllRoutes().Where(r => r.Places.Contains(place));
        }

        #endregion Methods
    }
}
