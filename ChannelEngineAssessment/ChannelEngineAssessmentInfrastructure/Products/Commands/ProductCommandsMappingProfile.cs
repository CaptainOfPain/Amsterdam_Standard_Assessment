using AutoMapper;
using ChannelEngineAssessmentDomain.Products.DataStructures;

namespace ChannelEngineAssessmentInfrastructure.Products.Commands
{
    public class ProductCommandsMappingProfile : Profile
    {
        public ProductCommandsMappingProfile()
        {
            CreateMap<CreateProductCommand, ProductDataStructure>()
                .ConstructUsing(x => 
                    new ProductDataStructure(
                        x.MerchantProductNo, 
                        x.IsActive,
                        x.ExtraData,
                        x.Name, 
                        x.Description,
                        x.Brand,
                        x.Size,
                        x.Color,
                        x.Ean,
                        x.ManufacturerProductNumber,
                        x.Price,
                        x.MSRP,
                        x.PurchasePrice,
                        x.VatRateType,
                        x.ShippingCost,
                        x.ShippingTime,
                        x.Url,
                        x.ImageUrl,
                        x.CategoryTrail,
                        x.ExtraImageUrls));

            CreateMap<UpdateProductCommand, ProductDataStructure>()
                .ConstructUsing(x => 
                    new ProductDataStructure(
                        x.MerchantProductNo,
                        x.IsActive,
                        x.ExtraData,
                        x.Name,
                        x.Description,
                        x.Brand,
                        x.Size,
                        x.Color,
                        x.Ean,
                        x.ManufacturerProductNumber,
                        x.Price,
                        x.MSRP,
                        x.PurchasePrice,
                        x.VatRateType,
                        x.ShippingCost,
                        x.ShippingTime,
                        x.Url,
                        x.ImageUrl,
                        x.CategoryTrail,
                        x.ExtraImageUrls));
        }
    }
}
