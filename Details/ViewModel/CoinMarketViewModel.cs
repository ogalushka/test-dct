using DCT.MVVM;
using DCT.Service;
using DCT.Service.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DCT.Details.ViewModel
{
    public class CoinMarketViewModel : ViewModelBase
    {
        public MarketDto Dto { get; private set; }
        private readonly CoinApiService service;

        public CoinMarketViewModel(MarketDto marketDto, CoinApiService service)
        {
            Dto = marketDto;
            this.service = service;

            OpenMarketWebPage = new DelegateCommandAsync(OpenExchangePage);
        }

        private async Task OpenExchangePage()
        {
            var url = await service.GetExchangeUrl(Dto.ExchangeId);
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show($"Error retrieving Exchange Url for {Dto.ExchangeId}");
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        public string Name => Dto.ExchangeId;
        public string Price => Dto.PriceQuote;

        public ICommand OpenMarketWebPage { get; private set; }
    }
}
