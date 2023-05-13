using System;

namespace DCT.Service.Data
{
    public class CoinDto
    {
        public string Id { get; set; } = string.Empty;
        public string Rank { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Supply { get; set; } = string.Empty;
        public string? MaxSupply { get; set; } 
        public string MarketCapUsd { get; set; } = string.Empty;
        public string VolumeUsd24Hr { get; set; } = string.Empty;
        public string PriceUsd { get; set; } = string.Empty;
        public string ChangePercent24Hr { get; set; } = string.Empty;
        public string Vwap24Hr { get; set; } = string.Empty;
    }

    public class AssetsDto
    {
        public CoinDto[] Data { get; set; } = Array.Empty<CoinDto>();
    }
}
