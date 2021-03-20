using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelEngineAssessmentDomain.MerchantOrders;
using ChannelEngineAssessmentShared.Infrastructure.Repositories.Abstractions;

namespace ChannelEngineAssessmentInfrastructure.MerchantOrders.Repositories
{
    public interface IMerchantOrderRepository : IGenericRepository<MerchantOrder>
    {
        Task<IEnumerable<MerchantOrder>> BrowseAsync(IEnumerable<OrderStatus> statuses = null, IEnumerable<string> emailAddresses = null,
            DateTime? fromDate = null, DateTime? toDate = null, DateTime? fromCreatedAtDate = null);
    }
}
