using System;

namespace DCT.Service.Data
{
    public class CoinDto
    {
        public string Id { get; set; } = string.Empty;// "bitcoin",
        public string Rank { get; set; } = string.Empty;//"rank": "1",
        public string Symbol { get; set; } = string.Empty;// "BTC",
        public string Name { get; set; } = string.Empty;// "Bitcoin",
        public string Supply { get; set; } = string.Empty;// "supply": "17193925.0000000000000000",
        public string? MaxSupply { get; set; } //"maxSupply": "21000000.0000000000000000",
        public string MarketCapUsd { get; set; } = string.Empty; //"marketCapUsd": "119150835874.4699281625807300",
        public string VolumeUsd24Hr { get; set; } = string.Empty; //"volumeUsd24Hr": "2927959461.1750323310959460",
        public string PriceUsd { get; set; } = string.Empty;// "priceUsd": "6929.8217756835584756",
        public string ChangePercent24Hr { get; set; } = string.Empty;// "-0.8101417214350335",
        public string Vwap24Hr { get; set; } // : "7175.0663247679233209"
    }

    public class AssetsDto
    {
        public CoinDto[] Data { get; set; } = Array.Empty<CoinDto>();
    }
}
