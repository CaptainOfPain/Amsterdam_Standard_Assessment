using System.Collections.Generic;
using ChannelEngineAssessmentDomain.MerchantOrders;
using ChannelEngineAssessmentShared.Infrastructure.Abstractions;

namespace ChannelEngineAssessmentInfrastructure.Products.Queries
{
    public class GetTopSoldProductsQuery : IQuery
    {
        public GetTopSoldProductsQuery(int topProductsNumber = 5)
        {
            TopProductsNumber = topProductsNumber;
            OrderStatuses = new List<OrderStatus>() {OrderStatus.InProgress};
        }

        public int TopProductsNumber { get; }
        public IEnumerable<OrderStatus> OrderStatuses { get; }
    }
}
