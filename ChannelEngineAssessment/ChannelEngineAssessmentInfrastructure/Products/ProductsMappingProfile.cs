using System.Linq;
using AutoMapper;
using ChannelEngineAssessmentDomain.Products;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;
using ChannelEngineAssessmentInfrastructure.Products.Requests;
using ChannelEngineAssessmentShared.Extensions;

namespace ChannelEngineAssessmentInfrastructure.Products
{
    public class ProductsMappingProfile : Profile
    {
        public ProductsMappingProfile()
        {
            CreateMap<Product, UpsertProductRequest>()
                .ConstructUsing(aggregate => new UpsertProductRequest(
                    aggregate.Id.Id,
                    aggregate.Name,
                    aggregate.Description,
                    aggregate.Brand,
                    aggregate.Size,
                    aggregate.Color,
                    aggregate.Ean,
                    aggregate.ManufacturerProductNumber,
                    aggregate.Stock,
                    aggregate.Price,
                    aggregate.MSRP,
                    aggregate.PurchasePrice,
                    aggregate.VatRateType.GetEnumMemberValue(),
                    aggregate.ShippingCost,
                    aggregate.ShippingTime,
                    aggregate.Url,
                    aggregate.ImageUrl,
                    aggregate.ExtraImageUrl1,
                    aggregate.ExtraImageUrl2,
                    aggregate.ExtraImageUrl3,
                    aggregate.ExtraImageUrl4,
                    aggregate.ExtraImageUrl5,
                    aggregate.ExtraImageUrl6,
                    aggregate.ExtraImageUrl7,
                    aggregate.ExtraImageUrl8,
                    aggregate.ExtraImageUrl9,
                    aggregate.CategoryTrail,
                    aggregate.ExtraData.Select(x => new ProductExtraDataDto(x.Key, x.Value, x.Type.GetEnumMemberValue(), x.IsPublic)).ToList()));
        }
    }
}
