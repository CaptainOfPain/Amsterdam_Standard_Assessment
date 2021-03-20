using System.Collections.Generic;
using ChannelEngineAssessmentDomain.Products;
using ChannelEngineAssessmentShared.Domain;

namespace ChannelEngineAssessmentInfrastructure.Products.Commands
{
    public class UpdateProductCommand : CreateProductCommand
    {
        public UpdateProductCommand(AggregateId merchantProductNo, bool isActive, IEnumerable<ProductExtraData> extraData, string name, string description, string brand, string size, string color, string ean, string manufacturerProductNumber, decimal price, decimal msrp, decimal purchasePrice, VatRateType vatRateType, decimal shippingCost, string shippingTime, string url, string imageUrl, string categoryTrail, IEnumerable<string> extraImageUrls) : base(merchantProductNo, isActive, extraData, name, description, brand, size, color, ean, manufacturerProductNumber, price, msrp, purchasePrice, vatRateType, shippingCost, shippingTime, url, imageUrl, categoryTrail, extraImageUrls)
        {
        }
    }
}