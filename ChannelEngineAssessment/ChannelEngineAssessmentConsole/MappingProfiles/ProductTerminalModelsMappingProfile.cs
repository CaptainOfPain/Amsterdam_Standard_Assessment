using AutoMapper;
using ChannelEngineAssessmentConsole.Models;
using ChannelEngineAssessmentInfrastructure.Products.DTOs;

namespace ChannelEngineAssessmentConsole.MappingProfiles
{
    public class ProductTerminalModelsMappingProfile : Profile
    {
        public ProductTerminalModelsMappingProfile()
        {
            CreateMap<TopSoldProductDto, TopSoldProductTerminalModel>();
        }
    }
}
