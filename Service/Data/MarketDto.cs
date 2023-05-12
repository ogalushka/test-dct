using System;

namespace DCT.Service.Data
{
    public class MarketDto
    {
        public string ExchangeId { get; set; } = string.Empty;
        public string PriceQuote { get; set; } = string.Empty;
    }

    public class MarketsDto
    {
        public MarketDto[] Data { get; set; } = Array.Empty<MarketDto>();
    }
}
