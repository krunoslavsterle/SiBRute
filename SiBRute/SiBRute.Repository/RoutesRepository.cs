using SiBRute.DAL;
using SiBRute.DAL.Entities;
using SiBRute.Model.Common;
using SiBRute.Repository.Common;
using System.Collections.Generic;

namespace SiBRute.Repository
{
    public class RoutesRepository : IRoutesRepository
    {
        #region Properties

        /// <summary>
        /// Gets and sets the context of the database.
        /// </summary>
        protected RoutesDbContext context { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialize a new instance of the <see cref="RoutesRepository"/> class.
        /// </summary>
        public RoutesRepository()
        {
            context = new RoutesDbContext();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets all routes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBikeRoute> GetAllRoutes()
        {           
            return context.Routes;           
        }

        /// <summary>
        /// Add or update route in repository
        /// </summary>
        /// <param name="route">The route object</param>
        /// <returns></returns>
        public bool AddRoute(IBikeRoute route)
        {
            if (route.Id == 0)
            {
                context.Routes.Add(route as BikeRouteEntity);
            }
            else
            {
                BikeRouteEntity dbEntry = context.Routes.Find(route);

                if (dbEntry != null)
                {
                    dbEntry.Name = route.Name;
                    dbEntry.Description = route.Description;
                    dbEntry.Author = route.Author;
                    dbEntry.DateCreated = route.DateCreated;
                    dbEntry.Distance = route.Distance;
                    dbEntry.Places = route.Places;
                }
            }

            context.SaveChanges();
            return true;

        }

        /// <summary>
        /// Remove route from repositroy
        /// </summary>
        /// <param name="routeId">The route indentifier</param>
        /// <returns></returns>
        public bool RemoveRoute (int routeId)
        {
            BikeRouteEntity dbEntry = context.Routes.Find(routeId);

            if (dbEntry != null)
            {
                context.Routes.Remove(dbEntry);
                context.SaveChanges();

                return true;
            }

            return false;
        }

        #endregion Methods
    }
}
