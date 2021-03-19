using System.Collections.Generic;
using ChannelEngineAssessmentDomain.MerchantOrders.DataStructures;

namespace ChannelEngineAssessmentDomain.MerchantOrders.Factories
{
    public class MerchantOrderDomainFactory : IMerchantOrderDomainFactory
    {
        public MerchantOrder Create(MerchantOrderDataStructure dataStructure)
        {
            var order = new MerchantOrder(dataStructure.ChannelOrderNo, dataStructure);
            AssignLinesToOrder(order, dataStructure.Lines);

            return order;
        }

        private void AssignLinesToOrder(MerchantOrder order, IEnumerable<MerchantOrderLineDataStructure> dataStructureLines)
        {
            foreach (var merchantOrderLineDataStructure in dataStructureLines)
            {
                order.AddLine(merchantOrderLineDataStructure);
            }
        }
    }
}