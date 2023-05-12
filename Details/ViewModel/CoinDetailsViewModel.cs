using DCT.List.ViewModel;
using DCT.MVVM;
using DCT.Service;
using DCT.Service.Data;
using DCT.Store;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DCT.Details.ViewModel
{
    public class CoinDetailsViewModel : ViewModelBase
    {
        private readonly CoinDto coinDto;
        private readonly CoinApiService service;
        private readonly Navigation navigation;

        public CoinDetailsViewModel(CoinDto coinDto, CoinApiService service, Navigation navigation)
        {
            this.coinDto = coinDto;
            this.service = service;
            this.navigation = navigation;

            Markets = new();

            BackCommand = new DelegateCommand(NavigateBack);

            LoadMarkets();
        }


        private async void LoadMarkets()
        {
            var markets = await service.GetMarkets(coinDto.Symbol);
            Markets.Clear();
            foreach (var market in markets)
            {
                Markets.Add(new CoinMarketViewModel(market, service));
            }
        }

        private void NavigateBack()
        {
            navigation.SetViewModel<CoinListViewModel>();
        }

        public string CoinName => coinDto.Name;
        public string Price => coinDto.PriceUsd;
        public string Volume => coinDto.VolumeUsd24Hr;
        public string PriceChange => coinDto.ChangePercent24Hr;
        public ObservableCollection<CoinMarketViewModel> Markets { get; private set; }


        public ICommand BackCommand { get; private set; }
    }
}
