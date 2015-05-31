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
                
        protected IUnitOfWork unitOfWork { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialize a new instance of the <see cref="RoutesService"/> class.
        /// </summary>
        /// <param name="repository"></param>
        public RoutesService(IUnitOfWork unitOfWork)
        {     
            this.unitOfWork = unitOfWork;
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
            await unitOfWork.AddAsync(route);
            return await unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Remove route from repositroy asynchronously
        /// </summary>
        /// <param name="routeId">The route indentifier</param>
        /// <returns></returns>
        public async Task<int> RemoveRouteAsync(int routeId)
        {
            await unitOfWork.DeleteAsync<BikeRoute>(routeId);
            return await unitOfWork.CommitAsync();
        }
               

        /// <summary>
        /// Gets specific route by provided route identifier asynchronously
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public async Task<BikeRoute> GetRouteAsync(int routeId)
        {            
            return await unitOfWork.Get<BikeRoute>(r => r.Id == routeId);
        }
               

        /// <summary>
        /// Gets all the routes from repository asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<List<BikeRoute>> GetAllRoutesAsync()
        {
            return await unitOfWork.GetAllAsync<BikeRoute>();
        }

        /// <summary>
        /// Gets all routes that dont have greater distance than param asynchronously
        /// </summary>
        /// <param name="maxDistance">Max distance of the route</param>
        /// <returns></returns>
        public async Task<List<BikeRoute>> GetRoutesWithMaxDistanceAsync(int maxDistance)
        {
            return await unitOfWork.GetAllAsync<BikeRoute>(r => r.Distance < maxDistance);
        }

        /// <summary>
        /// Gets all routes that are near designated place asynchronously
        /// </summary>
        /// <param name="place">Name of the place on the route</param>
        /// <returns></returns>
        public async Task<List<BikeRoute>> GetRoutesNearPlaceAsync(string place)
        {
            return await unitOfWork.GetAllAsync<BikeRoute>(r => r.Places.Contains(place));
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
                    unitOfWork.Dispose();
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
