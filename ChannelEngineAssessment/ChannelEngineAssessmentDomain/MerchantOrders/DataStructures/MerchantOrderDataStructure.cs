using System;
using System.Collections.Generic;
using System.Linq;
using ChannelEngineAssessmentShared.Domain;

namespace ChannelEngineAssessmentDomain.MerchantOrders.DataStructures
{
    public class MerchantOrderDataStructure
    {
        public int ChannelId { get; }
        public string ChannelName { get; }
        public int GlobalChannelId { get; }
        public string GlobalChannelName { get; }
        public OrderSupport ChannelOrderSupport { get; }
        public AggregateId ChannelOrderNo { get; }
        public OrderStatus Status { get; }
        public bool IsBusinessOrder { get; }
        public string MerchantComment { get; }
        public Address BillingAddress { get; }
        public Address ShippingAddress { get; }
        public PriceWithVat? SubTotalPriceWithVat { get; }
        public PriceWithVat? TotalPriceWithVat { get; }
        public PriceWithVat? ShippingPriceWithVat { get; }
        public PriceWithVat? OriginalSubtotalPriceWithVat { get; }
        public PriceWithVat? OriginalTotalPriceWithVat { get; }
        public PriceWithVat OriginalShippingPriceWithVat { get; }
        public string Phone { get; }
        public string Email { get;  }
        public string CompanyRegistrationNo { get; }
        public string VatNo { get; }
        public string PaymentMethod { get; }
        public string CurrencyCode { get; }
        public DateTime OrderDate { get; }
        public string ChannelCustomerNo { get; }
        public Dictionary<string, string> ExtraData { get; }
        public IEnumerable<MerchantOrderLineDataStructure> Lines { get; }

        public MerchantOrderDataStructure(int channelId, string channelName, int globalChannelId, string globalChannelName, OrderSupport channelOrderSupport, AggregateId channelOrderNo, OrderStatus status, bool isBusinessOrder, string merchantComment, Address billingAddress, Address shippingAddress, decimal subTotalInclVat, decimal subTotalVat, decimal totalInclVat, PriceWithVat? subTotalPriceWithVat, PriceWithVat? totalPriceWithVat, PriceWithVat? shippingPriceWithVat, PriceWithVat? originalSubtotalPriceWithVat, PriceWithVat? originalTotalPriceWithVat, PriceWithVat originalShippingPriceWithVat, string phone, string email, string companyRegistrationNo, string vatNo, string paymentMethod, string currencyCode, DateTime orderDate, string channelCustomerNo, Dictionary<string, string> extraData, IEnumerable<MerchantOrderLineDataStructure> lines)
        {
            ChannelId = channelId;
            ChannelName = channelName;
            GlobalChannelId = globalChannelId;
            GlobalChannelName = globalChannelName;
            ChannelOrderSupport = channelOrderSupport;
            ChannelOrderNo = channelOrderNo;
            Status = status;
            IsBusinessOrder = isBusinessOrder;
            MerchantComment = merchantComment;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            SubTotalPriceWithVat = subTotalPriceWithVat;
            TotalPriceWithVat = totalPriceWithVat;
            ShippingPriceWithVat = shippingPriceWithVat;
            OriginalSubtotalPriceWithVat = originalSubtotalPriceWithVat;
            OriginalTotalPriceWithVat = originalTotalPriceWithVat;
            OriginalShippingPriceWithVat = originalShippingPriceWithVat;
            Phone = phone;
            Email = email;
            CompanyRegistrationNo = companyRegistrationNo;
            VatNo = vatNo;
            PaymentMethod = paymentMethod;
            CurrencyCode = currencyCode;
            OrderDate = orderDate;
            ChannelCustomerNo = channelCustomerNo;
            ExtraData = extraData;
            Lines = lines ?? new List<MerchantOrderLineDataStructure>();
        }
    }
}
