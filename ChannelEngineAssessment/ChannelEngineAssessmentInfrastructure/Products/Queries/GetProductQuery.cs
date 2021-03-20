using ChannelEngineAssessmentShared.Domain;
using ChannelEngineAssessmentShared.Infrastructure.Abstractions;

namespace ChannelEngineAssessmentInfrastructure.Products.Queries
{
    public class GetProductQuery : IQuery
    {
        public GetProductQuery(AggregateId merchantProductNo)
        {
            MerchantProductNo = merchantProductNo;
        }

        public AggregateId MerchantProductNo { get; }
    }
}
