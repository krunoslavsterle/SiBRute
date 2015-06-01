using SiBRute.DAL;
using SiBRute.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq.Expressions;
using SiBRute.Model;

namespace SiBRute.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected RoutesDbContext DbContext { get; set; }

        public UnitOfWork(RoutesDbContext dbContext)
        {
            DbContext = dbContext;
        }

        #region Methods

        /// <summary>
        /// Commit(Save) all the changes done to the repository
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync()
        {
            int result = 0;

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await DbContext.SaveChangesAsync();
                scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// Insert entity to the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task<int> AddAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Detached)
                {
                    dbEntityEntry.State = EntityState.Added;
                }
                else
                {
                    DbContext.Set<T>().Add(entity);
                }

                return Task.FromResult(1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Update entity in the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task<int> UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);

                if (dbEntityEntry.State == EntityState.Detached)
                {
                    DbContext.Set<T>().Attach(entity);
                }

                dbEntityEntry.State = EntityState.Modified;

                return Task.FromResult(1);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Delete entity from the database by entity object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntityEntry = DbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    DbContext.Set<T>().Attach(entity);
                    DbContext.Set<T>().Remove(entity);
                }

                return Task.FromResult(1);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Delete entity for the database by entity indentifier
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Task<int> DeleteAsync<T>(int id) where T : class
        {
            try
            {
                var entity = DbContext.Set<T>().Find(id);

                if (entity == null)
                {
                    return Task.FromResult(0);
                }

                return DeleteAsync<T>(entity);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        

        public void Dispose()
        {
            DbContext.Dispose();
        }

        #endregion Methods
    }


}
