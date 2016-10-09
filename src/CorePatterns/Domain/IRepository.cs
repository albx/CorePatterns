using System;
using System.Threading.Tasks;

namespace CorePatterns.Domain
{
    /// <summary>
    /// Represents a generic repository
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Add the specified aggregate
        /// </summary>
        /// <typeparam name="TAggregate">The aggregate's type</typeparam>
        /// <param name="model">The aggregate to add</param>
        void Add<TAggregate>(TAggregate model) where TAggregate : IAggregateRoot;

        /// <summary>
        /// Get the aggregate by its key
        /// </summary>
        /// <typeparam name="TAggregate">The aggregate's type</typeparam>
        /// <param name="id">The id of the aggregate to find</param>
        /// <returns>The aggregate found</returns>
        TAggregate GetByKey<TAggregate>(Guid id) where TAggregate : IAggregateRoot;

        /// <summary>
        /// Get the aggregate by its key in an async way
        /// </summary>
        /// <typeparam name="TAggregate">The aggregate's type</typeparam>
        /// <param name="id">The id of the aggregate to find</param>
        /// <returns>The aggregate found</returns>
        Task<TAggregate> GetByKeyAsync<TAggregate>(Guid id) where TAggregate : IAggregateRoot;

        /// <summary>
        /// Save all the changes made
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Save all the changes made in an async way
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
