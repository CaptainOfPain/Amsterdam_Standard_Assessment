using ChannelEngineAssessmentInfrastructure.Products.DTOs;

namespace ChannelEngineAssessmentConsole.Models
{
    public class TopSoldProductTerminalModel : TopSoldProductDto
    {
        public override string ToString()
        {
            return $"No.: {MerchantProductNo.Id} | Name: {Name} | EAN: {EAN} | Total quantity: {TotalQuantity}";
        }
    }
}
