using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChannelEngineAssessmentInfrastructure;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;
using ChannelEngineAssessmentWeb.ViewModels;
using ChannelEngineAssessmentWeb.ViewModels.Products;

namespace ChannelEngineAssessmentWeb.MappingProfiles.Products
{
    public class ProductsControllerMappingProfile : Profile
    {
        public ProductsControllerMappingProfile()
        {
            CreateMap<TopSoldProductDto, TopSoldProductViewModel>()
                .ForMember(x => x.MerchantProductNo, opt => opt.MapFrom(x => x.MerchantProductNo.ToString()));

            CreateMap<ListResultDto<TopSoldProductDto>, ListResultViewModel<TopSoldProductViewModel>>()
                .ForMember(x => x.Items, opt => opt.MapFrom(x => x.Items));

            CreateMap<ProductDto, ProductViewModel>()
                .ForMember(x => x.ExtraImageUrls, opt => opt.MapFrom(x => x.ExtraImageUrls))
                .ForMember(x => x.ExtraData, opt => opt.MapFrom(x => x.ExtraData));

            CreateMap<ProductExtraDataDto, ProductExtraDataViewModel>();
            CreateMap<ExtraImageUrlDto, ExtraImageUrlViewModel>();
        }
    }
}
