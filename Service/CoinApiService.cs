using DCT.Service.Data;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace DCT.Service
{
    // TODO error handling
    public class CoinApiService
    {
        private readonly HttpClient httpClient;
        private CoinDto[] topCoins = Array.Empty<CoinDto>();

        public CoinApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CoinDto[]> GetTopCoins()
        {
            try
            {
                if (topCoins.Length == 0)
                {
                    var responce = await httpClient.GetFromJsonAsync<AssetsDto>("https://api.coincap.io/v2/assets?limit=10",
                        new JsonSerializerOptions(JsonSerializerDefaults.Web));
                    topCoins = responce != null ? responce.Data : Array.Empty<CoinDto>();
                }

                return topCoins;
            }
            catch
            {
                return Array.Empty<CoinDto>();
            }
        }

        public async Task<CoinDto[]> Search(string query)
        {
            try
            {
                var responce = await httpClient.GetFromJsonAsync<AssetsDto>($"https://api.coincap.io/v2/assets?search={query}",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));
                return responce != null ? responce.Data : Array.Empty<CoinDto>();
            }
            catch
            {
                return Array.Empty<CoinDto>();
            }
        }

        public async Task<MarketDto[]> GetMarkets(string currencySymbol)
        {
            try
            {
                var responce = await httpClient.GetFromJsonAsync<MarketsDto>($"https://api.coincap.io/v2/markets?baseSymbol={currencySymbol}&quoteSymbol=USD",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));
                return responce != null ? responce.Data : Array.Empty<MarketDto>();
            }
            catch
            {
                return Array.Empty<MarketDto>();
            }
        }

        public async Task<string> GetExchangeUrl(string exchangeId)
        {
            try
            {
                var responce = await httpClient.GetFromJsonAsync<ExchangeDtoResponse>($"https://api.coincap.io/v2/exchanges/{exchangeId}",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));
                return responce != null ? responce.Data.ExchangeUrl : string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
