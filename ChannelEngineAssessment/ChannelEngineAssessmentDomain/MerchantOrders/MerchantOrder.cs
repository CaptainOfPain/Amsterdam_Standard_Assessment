using System;
using System.Collections.Generic;
using System.Linq;
using ChannelEngineAssessmentDomain.MerchantOrders.DataStructures;
using ChannelEngineAssessmentShared.Domain;

namespace ChannelEngineAssessmentDomain.MerchantOrders
{
    public class MerchantOrder : AggregateRoot
    {
        public int ChannelId { get; private set; }
        public string ChannelName { get; private set; }
        public int GlobalChannelId { get; private set; }
        public string GlobalChannelName { get; private set; }
        public OrderSupport ChannelOrderSupport { get; private set; }
        public OrderStatus Status { get; private set; }
        public bool IsBusinessOrder { get; private set; }
        public string MerchantComment { get; private set; }
        public Address BillingAddress { get; private set; }
        public Address ShippingAddress { get; private set; }
        public PriceWithVat? SubTotalPriceWithVat { get; private set; }
        public PriceWithVat? TotalPriceWithVat { get; private set; }
        public PriceWithVat? ShippingPriceWithVat { get; private set; }
        public PriceWithVat? OriginalSubtotalPriceWithVat { get; private set; }
        public PriceWithVat? OriginalTotalPriceWithVat { get; private set; }
        public PriceWithVat OriginalShippingPriceWithVat { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string CompanyRegistrationNo { get; private set; }
        public string VatNo { get; private set; }
        public string PaymentMethod { get; private set; }
        public string CurrencyCode { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string ChannelCustomerNo { get; private set; }
        public Dictionary<string, string> ExtraData { get; private set; }

        private List<MerchantOrderLine> _lines = new List<MerchantOrderLine>();
        public IEnumerable<MerchantOrderLine> Lines
        {
            get => _lines;
            private set => _lines = value.ToList();
        }


        internal MerchantOrder(AggregateId id, MerchantOrderDataStructure merchantOrderDataStructure) : base(id)
        {
            AssignDataStructure(merchantOrderDataStructure);
        }

        private MerchantOrder()
        {

        }

        public void AddLine(MerchantOrderLineDataStructure dataStructure)
        {
            _lines.Add(new MerchantOrderLine(dataStructure));
        }

        private void AssignDataStructure(MerchantOrderDataStructure merchantOrderDataStructure)
        {
            ChannelId = merchantOrderDataStructure.ChannelId;
            ChannelName = merchantOrderDataStructure.ChannelName;
            GlobalChannelId = merchantOrderDataStructure.GlobalChannelId;
            GlobalChannelName = merchantOrderDataStructure.GlobalChannelName;
            ChannelOrderSupport = merchantOrderDataStructure.ChannelOrderSupport;
            Status = merchantOrderDataStructure.Status;
            IsBusinessOrder = merchantOrderDataStructure.IsBusinessOrder;
            MerchantComment = merchantOrderDataStructure.MerchantComment;
            BillingAddress = merchantOrderDataStructure.BillingAddress;
            ShippingAddress = merchantOrderDataStructure.ShippingAddress;
            SubTotalPriceWithVat = merchantOrderDataStructure.SubTotalPriceWithVat;
            TotalPriceWithVat = merchantOrderDataStructure.TotalPriceWithVat;
            ShippingPriceWithVat = merchantOrderDataStructure.ShippingPriceWithVat;
            OriginalSubtotalPriceWithVat = merchantOrderDataStructure.OriginalSubtotalPriceWithVat;
            OriginalTotalPriceWithVat = merchantOrderDataStructure.OriginalTotalPriceWithVat;
            OriginalShippingPriceWithVat = merchantOrderDataStructure.OriginalShippingPriceWithVat;
            Phone = merchantOrderDataStructure.Phone;
            Email = merchantOrderDataStructure.Email;
            CompanyRegistrationNo = merchantOrderDataStructure.CompanyRegistrationNo;
            VatNo = merchantOrderDataStructure.VatNo;
            PaymentMethod = merchantOrderDataStructure.PaymentMethod;
            CurrencyCode = merchantOrderDataStructure.CurrencyCode;
            OrderDate = merchantOrderDataStructure.OrderDate;
            ChannelCustomerNo = merchantOrderDataStructure.ChannelCustomerNo;
            ExtraData = merchantOrderDataStructure.ExtraData;
        }
    }
}
