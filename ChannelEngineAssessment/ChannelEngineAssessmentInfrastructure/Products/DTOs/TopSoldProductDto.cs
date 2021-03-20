using System.Collections.Generic;
using ChannelEngineAssessmentShared.Domain;
using ChannelEngineAssessmentShared.Infrastructure.Abstractions;

namespace ChannelEngineAssessmentInfrastructure.Products.DTOs
{
    public class TopSoldProductDto
    {
        public AggregateId MerchantProductNo { get; set; }
        public string Name { get; set; }
        public string EAN { get; set; }
        public int TotalQuantity { get; set; }
    }
}
