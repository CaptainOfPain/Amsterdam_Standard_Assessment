using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelEngineAssessmentShared.Domain;

namespace ChannelEngineAssessmentShared.Infrastructure.Repositories.Abstractions
{
    public interface IGenericRepository<TAggregate> : IRepository where TAggregate : AggregateRoot
    {
        Task CreateAsync(TAggregate aggregate);
        Task UpdateAsync(TAggregate aggregate);
        Task<TAggregate> GetAsync(AggregateId id);
        Task<IEnumerable<TAggregate>> GetAllAsync();
        Task DeleteAsync(AggregateId id);
    }
}