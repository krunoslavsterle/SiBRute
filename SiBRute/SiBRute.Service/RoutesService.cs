﻿using SiBRute.Service.Common;
using System.Collections.Generic;
using System.Linq;
using SiBRute.Repository.Common;

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
        public bool AddRoute(Model.Common.IBikeRoute route)
        {
            return repository.AddRoute(route);
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
        /// Gets all routes from repository
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.Common.IBikeRoute> GetAllRoutes()
        {
            return repository.GetAllRoutes();
        }

        /// <summary>
        /// Gets all routes that dont have greater distance than param
        /// </summary>
        /// <param name="maxDistance">Max distance of the route</param>
        /// <returns></returns>
        public IEnumerable<Model.Common.IBikeRoute> GetRoutesWithMaxDistance(int maxDistance)
        {            
            return repository.GetAllRoutes().Where(r => (r.Distance <= maxDistance));
        }

        /// <summary>
        /// Gets all routes that are near designated place
        /// </summary>
        /// <param name="place">Name of the place on the route</param>
        /// <returns></returns>
        public IEnumerable<Model.Common.IBikeRoute> GetRoutesNearPlace(string place)
        {            
            return repository.GetAllRoutes().Where(r => r.Places.Contains(place));
        }

        #endregion Methods
    }
}
