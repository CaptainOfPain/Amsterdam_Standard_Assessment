using AutoMapper;
using ChannelEngineAssessmentDomain;
using ChannelEngineAssessmentDomain.MerchantOrders;
using ChannelEngineAssessmentInfrastructure.MerchantOrders.DTOs;
using ChannelEngineAssessmentShared.Domain;

namespace ChannelEngineAssessmentInfrastructure.MerchantOrders
{
    public class MerchantOrderMappingProfile : Profile
    {
        public MerchantOrderMappingProfile()
        {
            CreateMap<MerchantOrderResponseDto, MerchantOrder>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => new AggregateId(x.ChannelOrderNo)))
                .ForMember(x => x.OriginalShippingPriceWithVat,
                    opt => opt.MapFrom(
                        x => new PriceWithVat(x.OriginalShippingCostsVat, x.OriginalShippingCostsInclVat)))
                .ForMember(x => x.OriginalSubtotalPriceWithVat,
                    opt => opt.MapFrom(x => new PriceWithVat(x.OriginalSubTotalVat ?? 0m, x.OriginalSubTotalVat ?? 0m)))
                .ForMember(x => x.OriginalTotalPriceWithVat,
                    opt => opt.MapFrom(x => new PriceWithVat(x.OriginalTotalVat ?? 0m, x.OriginalTotalInclVat ?? 0m)))
                .ForMember(x => x.ShippingPriceWithVat,
                    opt => opt.MapFrom(x => new PriceWithVat(x.ShippingCostsVat ?? 0m, x.ShippingCostsInclVat ?? 0m)))
                .ForMember(x => x.SubTotalPriceWithVat,
                    opt => opt.MapFrom(x => new PriceWithVat(x.SubTotalVat ?? 0m, x.OriginalSubTotalVat ?? 0m)))
                .ForMember(x => x.TotalPriceWithVat,
                    opt => opt.MapFrom(x => new PriceWithVat(x.TotalVat ?? 0m, x.TotalInclVat ?? 0m)))
                .ForMember(x => x.BillingAddress, opt => opt.MapFrom(x => x.BillingAddress))
                .ForMember(x => x.ShippingAddress, opt => opt.MapFrom(x => x.ShippingAddress));

            CreateMap<MerchantOrderLineResponseDto, MerchantOrderLine>()
                .ForMember(x => x.LineTotalPriceWithVat,
                    opt => opt.MapFrom(
                        x => new PriceWithVat(x.LineVat ?? 0m, x.LineTotalInclVat ?? 0m)))
                .ForMember(x => x.OriginalLineTotalPriceWithVat,
                    opt => opt.MapFrom(x =>
                        new PriceWithVat(x.OriginalLineVat ?? 0m, x.OriginalLineTotalInclVat ?? 0m)))
                .ForMember(x => x.OriginalUnitPriceWithVat,
                    opt => opt.MapFrom(x =>
                        new PriceWithVat(x.OriginalUnitVat ?? 0m, x.OriginalUnitPriceInclVat ?? 0m)));

            CreateMap<AddressDto, Address>()
                .ConstructUsing(x => new Address(x.Line1, x.Line2, x.Line3, x.Gender, x.CompanyName, x.FirstName,
                    x.LastName, x.StreetName, x.HouseNr, x.HouseNrAddition, x.ZipCode, x.City, x.Region, x.CountryIso,
                    x.Original));

            CreateMap<string, AggregateId>().ConstructUsing(x => new AggregateId(x));

        }
    }
}
