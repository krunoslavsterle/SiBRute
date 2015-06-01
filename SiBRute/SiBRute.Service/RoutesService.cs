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
    public class RoutesService : IRoutesService, IDisposable
    {
        #region Properties
                
        protected IRouteRepository repository { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialize a new instance of the <see cref="RoutesService"/> class.
        /// </summary>
        /// <param name="repository"></param>
        public RoutesService(IRouteRepository repository)
        {
            this.repository = repository;
        }       

        #endregion Constructors

        #region Methods
                
        /// <summary>
        /// Add or update route in repository asynchronously
        /// </summary>
        /// <param name="route">The route object</param>
        /// <returns></returns>
        public async Task<int> AddRouteAsync(BikeRoute route)
        {
            route.DateCreated = DateTime.Now;
            return await repository.AddRouteAsync(route);
        }

        /// <summary>
        /// Remove route from repositroy asynchronously
        /// </summary>
        /// <param name="routeId">The route indentifier</param>
        /// <returns></returns>
        public async Task<int> RemoveRouteAsync(int routeId)
        {
            return await repository.RemoveRouteAsync(routeId);            
        }
               

        /// <summary>
        /// Gets specific route by provided route identifier asynchronously
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public async Task<BikeRoute> GetRouteAsync(int routeId)
        {
            return await repository.GetAsync(r => r.Id == routeId);
        }
               

        /// <summary>
        /// Gets all the routes from repository asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<List<BikeRoute>> GetAllRoutesAsync()
        {
            return await repository.GetAllAsync();
        }

        /// <summary>
        /// Gets all routes that dont have greater distance than param asynchronously
        /// </summary>
        /// <param name="maxDistance">Max distance of the route</param>
        /// <returns></returns>
        public async Task<List<BikeRoute>> GetRoutesWithMaxDistanceAsync(int maxDistance)
        {
            return await repository.GetAllAsync(r => r.Distance <= maxDistance);
        }

        /// <summary>
        /// Gets all routes that are near designated place asynchronously
        /// </summary>
        /// <param name="place">Name of the place on the route</param>
        /// <returns></returns>
        public async Task<List<BikeRoute>> GetRoutesNearPlaceAsync(string place)
        {
            return await repository.GetAllAsync(r => r.Places.Contains(place));
        }

        #endregion Methods

        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    repository.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispose
       
    }
}
