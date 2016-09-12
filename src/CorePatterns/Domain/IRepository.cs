using System;
using System.Threading.Tasks;

namespace CorePatterns.Domain
{
    public interface IRepository
    {
        void Add<TAggregate>(TAggregate model) where TAggregate : AggregateRoot;

        TAggregate GetByKey<TAggregate>(Guid id) where TAggregate : AggregateRoot;

        Task<TAggregate> GetByKeyAsync<TAggregate>(Guid id) where TAggregate : AggregateRoot;

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
