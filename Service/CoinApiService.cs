using DCT.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DCT.Service
{
    public class CoinApiService
    {
        private readonly HttpClient httpClient;

        public CoinApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CoinDto[]> GetTopCoins()
        {
            try
            {
                var responce = await httpClient.GetFromJsonAsync<AssetsDto>("https://api.coincap.io/v2/assets?limit=10", new JsonSerializerOptions(JsonSerializerDefaults.Web));
                return responce != null ? responce.Data : Array.Empty<CoinDto>();
            }
            catch
            {
                return Array.Empty<CoinDto>();
            }
        }
    }
}
