using System;
using System.Collections.Generic;
using ChannelEngineAssessmentDomain.MerchantOrders.DataStructures;
using ChannelEngineAssessmentShared.Domain;

namespace ChannelEngineAssessmentDomain.MerchantOrders
{
    public class MerchantOrderLine
    {
        public OrderStatus Status { get; private set; }
        public bool IsFulfillmentByMarketplace { get; private set; }
        public string Gtin { get; private set; }
        public string Description { get; private set; }
        public decimal UnitVat { get; private set; }
        public PriceWithVat? LineTotalPriceWithVat { get; private set; }
        public PriceWithVat? OriginalUnitPriceWithVat { get; private set; }
        public PriceWithVat? OriginalLineTotalPriceWithVat { get; private set; }
        public decimal OriginalFeeFixed { get; private set; }
        public string BundleProductMerchantProductNo { get; private set; }
        public List<KeyValuePair<string, string>> ExtraData { get; private set; }
        public AggregateId ChannelProductNo { get; private set; }
        public AggregateId MerchantProductNo { get; private set; }
        public int Quantity { get; private set; }
        public int CancellationRequestedQuantity { get; private set; }
        public decimal UnitPriceInclVat { get; private set; }
        public decimal FeeFixed { get; private set; }
        public decimal FeeRate { get; private set; }
        public OrderLineCondition Condition { get; private set; }
        public DateTime ExpectedDeliveryDate { get; private set; }

        public MerchantOrderLine(MerchantOrderLineDataStructure dataStructure)
        {
            AssignFromDataStructure(dataStructure);
        }

        private MerchantOrderLine()
        {
            
        }

        private void AssignFromDataStructure(MerchantOrderLineDataStructure dataStructure)
        {
            Status = dataStructure.Status;
            IsFulfillmentByMarketplace = dataStructure.IsFulfillmentByMarketplace;
            Gtin = dataStructure.Gtin;
            Description = dataStructure.Description;
            UnitVat = dataStructure.UnitVat;
            LineTotalPriceWithVat = dataStructure.LineTotalPriceWithVat;
            OriginalUnitPriceWithVat = dataStructure.OriginalUnitPriceWithVat;
            OriginalLineTotalPriceWithVat = dataStructure.OriginalLineTotalPriceWithVat;
            OriginalFeeFixed = dataStructure.OriginalFeeFixed;
            BundleProductMerchantProductNo = dataStructure.BundleProductMerchantProductNo;
            ExtraData = dataStructure.ExtraData;
            ChannelProductNo = dataStructure.ChannelProductNo;
            MerchantProductNo = dataStructure.MerchantProductNo;
            Quantity = dataStructure.Quantity;
            CancellationRequestedQuantity = dataStructure.CancellationRequestedQuantity;
            UnitPriceInclVat = dataStructure.UnitPriceInclVat;
            FeeFixed = dataStructure.FeeFixed;
            FeeRate = dataStructure.FeeRate;
            Condition = dataStructure.Condition;
            ExpectedDeliveryDate = dataStructure.ExpectedDeliveryDate;
        }
    }
}