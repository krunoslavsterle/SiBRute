using SiBRute.DAL;
using SiBRute.Model;
using SiBRute.Repository.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace SiBRute.Repository
{
    public class RoutesRepository : IRoutesRepository, IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets and sets the context of the database.
        /// </summary>
        protected RoutesDbContext context { get; private set; }

        /// <summary>
        /// Gets and sets the unitOfWork
        /// </summary>
        protected UnitOfWork unitOfWork { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialize a new instance of the <see cref="RoutesRepository"/> class.
        /// </summary>
        public RoutesRepository()
        {
            context = new RoutesDbContext();
            unitOfWork = new UnitOfWork(context);
        }

        #endregion Constructors

        #region Methods
        
        /// <summary>
        /// Get List of routes asynchronously using predicate(default is null)
        /// </summary>
        /// <returns></returns>
        public async Task<List<BikeRoute>> GetAllAsync(Expression<Func<BikeRoute, bool>> predicate = null)
        {            
            if (predicate != null)
            {
                return await context.Set<BikeRoute>().Where(predicate).ToListAsync();
            }

            return await context.Set<BikeRoute>().ToListAsync();   
        }

        /// <summary>
        /// Get one route asynchronously using predicate 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<BikeRoute> GetAsync(Expression<Func<BikeRoute, bool>> predicate)
        {
            return await context.Set<BikeRoute>().FirstOrDefaultAsync(predicate);
        }
        
        /// <summary>
        /// Add or update route in repository asynchronously
        /// </summary>
        /// <param name="route">The route object</param>
        /// <returns></returns>
        public async Task<int> AddRouteAsync(BikeRoute route)
        {
            await unitOfWork.AddAsync(route);
            return await unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Update the route in repository asynchronously
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        public async Task<int> UpdateRouteAsync(BikeRoute route)
        {
            await unitOfWork.UpdateAsync(route);
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


        public void Dispose()
        {
            context.Dispose();
            unitOfWork.Dispose();
        }

        #endregion Methods
    }
}
