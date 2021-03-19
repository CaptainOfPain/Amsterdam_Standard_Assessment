namespace ChannelEngineAssessmentDomain.MerchantOrders
{
    public readonly struct PriceWithVat
    {
        public decimal Vat { get; }
        public decimal InclVat { get; }

        public PriceWithVat(decimal vat, decimal inclVat)
        {
            Vat = vat;
            InclVat = inclVat;
        }
    }
}