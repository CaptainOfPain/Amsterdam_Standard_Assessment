using ChannelEngineAssessmentShared.Domain;
using ChannelEngineAssessmentShared.Infrastructure.Abstractions;

namespace ChannelEngineAssessmentInfrastructure.Products.Commands
{
    public class SetProductStockCommand : ICommand
    {
        public AggregateId MerchantProductNo { get; }
        public int NewStock { get; }

        public SetProductStockCommand(AggregateId merchantProductNo, int newStock)
        {
            MerchantProductNo = merchantProductNo;
            NewStock = newStock;
        }
    }
}