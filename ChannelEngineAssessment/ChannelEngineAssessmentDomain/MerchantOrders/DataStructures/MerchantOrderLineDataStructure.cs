using System;
using System.Collections.Generic;
using ChannelEngineAssessmentShared.Domain;

namespace ChannelEngineAssessmentDomain.MerchantOrders.DataStructures
{
    public class MerchantOrderLineDataStructure
    {
        public OrderStatus Status { get; }
        public bool IsFulfillmentByMarketplace { get; }
        public string Gtin { get; }
        public string Description { get; }
        public decimal UnitVat { get; }
        public PriceWithVat? LineTotalPriceWithVat { get; }
        public PriceWithVat? OriginalUnitPriceWithVat { get; }
        public PriceWithVat? OriginalLineTotalPriceWithVat { get; }
        public decimal OriginalFeeFixed { get; }
        public string BundleProductMerchantProductNo { get; }
        public List<KeyValuePair<string, string>> ExtraData { get; }
        public AggregateId ChannelProductNo { get; }
        public AggregateId MerchantProductNo { get; }
        public int Quantity { get; }
        public int CancellationRequestedQuantity { get; }
        public decimal UnitPriceInclVat { get; }
        public decimal FeeFixed { get; }
        public decimal FeeRate { get; }
        public OrderLineCondition Condition { get; }
        public DateTime ExpectedDeliveryDate { get; }

        public MerchantOrderLineDataStructure(OrderStatus status, bool isFulfillmentByMarketplace, string gtin, string description,
            decimal unitVat, PriceWithVat? lineTotalPriceWithVat, PriceWithVat? originalUnitPriceWithVat, PriceWithVat? originalLineTotalPriceWithVat,
            decimal originalFeeFixed, string bundleProductMerchantProductNo, List<KeyValuePair<string, string>> extraData, AggregateId channelProductNo,
            AggregateId merchantProductNo, int quantity, int cancellationRequestedQuantity, decimal unitPriceInclVat, decimal feeFixed, decimal feeRate,
            OrderLineCondition condition, DateTime expectedDeliveryDate)
        {
            Status = status;
            IsFulfillmentByMarketplace = isFulfillmentByMarketplace;
            Gtin = gtin;
            Description = description;
            UnitVat = unitVat;
            LineTotalPriceWithVat = lineTotalPriceWithVat;
            OriginalUnitPriceWithVat = originalUnitPriceWithVat;
            OriginalLineTotalPriceWithVat = originalLineTotalPriceWithVat;
            OriginalFeeFixed = originalFeeFixed;
            BundleProductMerchantProductNo = bundleProductMerchantProductNo;
            ExtraData = extraData;
            ChannelProductNo = channelProductNo;
            MerchantProductNo = merchantProductNo;
            Quantity = quantity;
            CancellationRequestedQuantity = cancellationRequestedQuantity;
            UnitPriceInclVat = unitPriceInclVat;
            FeeFixed = feeFixed;
            FeeRate = feeRate;
            Condition = condition;
            ExpectedDeliveryDate = expectedDeliveryDate;
        }
    }
}