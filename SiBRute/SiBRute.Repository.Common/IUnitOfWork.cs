using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SiBRute.Model.Common;
using SiBRute.Model;


namespace SiBRute.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit(Save) all the changes done to the repository
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();

        /// <summary>
        /// Insert entity to the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Update entity in the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> UpdateAsync<T>(T entity) where T : class;

        /// <summary>
        /// Delete entity from the database by entity object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> DeleteAsync<T>(T entity) where T : class;

        /// <summary>
        /// Delete entity for the database by entity indentifier
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteAsync<T>(int id) where T : class;

        /// <summary>
        /// Get List of entities using predicate(default is null)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;

        /// <summary>
        /// Get one entity using predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
