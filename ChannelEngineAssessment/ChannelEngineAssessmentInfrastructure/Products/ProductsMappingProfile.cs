using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ChannelEngineAssessmentDomain.Products;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;
using ChannelEngineAssessmentInfrastructure.Products.DTOs.Responses;
using ChannelEngineAssessmentInfrastructure.Products.Requests;
using ChannelEngineAssessmentShared.Domain;
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
                    aggregate.ExtraImageUrls.FirstOrDefault() != null ? aggregate.ExtraImageUrls.FirstOrDefault().Url : null,
                    aggregate.ExtraImageUrls.Skip(1).FirstOrDefault() != null ? aggregate.ExtraImageUrls.Skip(1).FirstOrDefault().Url : null,
                    aggregate.ExtraImageUrls.Skip(2).FirstOrDefault() != null ? aggregate.ExtraImageUrls.Skip(2).FirstOrDefault().Url : null,
                    aggregate.ExtraImageUrls.Skip(3).FirstOrDefault() != null ? aggregate.ExtraImageUrls.Skip(3).FirstOrDefault().Url : null,
                    aggregate.ExtraImageUrls.Skip(4).FirstOrDefault() != null ? aggregate.ExtraImageUrls.Skip(4).FirstOrDefault().Url : null,
                    aggregate.ExtraImageUrls.Skip(5).FirstOrDefault() != null ? aggregate.ExtraImageUrls.Skip(5).FirstOrDefault().Url : null,
                    aggregate.ExtraImageUrls.Skip(6).FirstOrDefault() != null ? aggregate.ExtraImageUrls.Skip(6).FirstOrDefault().Url : null,
                    aggregate.ExtraImageUrls.Skip(7).FirstOrDefault() != null ? aggregate.ExtraImageUrls.Skip(7).FirstOrDefault().Url : null,
                    aggregate.ExtraImageUrls.Skip(8).FirstOrDefault() != null ? aggregate.ExtraImageUrls.Skip(8).FirstOrDefault().Url : null,
                    aggregate.CategoryTrail,
                    aggregate.ExtraData.Select(x => new ProductExtraDataRequest(x.Key, x.Value, x.Type.GetEnumMemberValue(), x.IsPublic)).ToList()));

            CreateMap<ProductResponseDto, Product>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => new AggregateId(x.MerchantProductNo)))
                .ForMember(x => x.ExtraImageUrls, opt => opt.MapFrom(
                    u =>
                        new List<ExtraImageUrl>()
                        {
                            new ExtraImageUrl(1, u.ExtraImageUrl1),
                            new ExtraImageUrl(2, u.ExtraImageUrl2),
                            new ExtraImageUrl(3, u.ExtraImageUrl3),
                            new ExtraImageUrl(4, u.ExtraImageUrl4),
                            new ExtraImageUrl(5, u.ExtraImageUrl5),
                            new ExtraImageUrl(6, u.ExtraImageUrl6),
                            new ExtraImageUrl(7, u.ExtraImageUrl7),
                            new ExtraImageUrl(8, u.ExtraImageUrl8),
                            new ExtraImageUrl(9, u.ExtraImageUrl9),
                        }))
                .ForMember(x => x.ExtraData,
                    opt => opt.MapFrom(x =>
                        x.ExtraData.Select(d => new ProductExtraData(d.Key, d.Value, d.Type, d.IsPublic))));

            CreateMap<Product, ProductDto>()
                .ForMember(x => x.MerchantProductNo, opt => opt.MapFrom(x => x.Id.Id))
                .ForMember(x => x.ExtraData, opt => opt.MapFrom(x => x.ExtraData))
                .ForMember(x => x.ExtraImageUrls, opt => opt.MapFrom(x => x.ExtraImageUrls));

            CreateMap<ProductExtraData, ProductExtraDataDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.Type));

            CreateMap<ExtraImageUrl, ExtraImageUrlDto>();
        }
    }
}
