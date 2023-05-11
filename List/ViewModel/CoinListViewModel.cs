using DCT.Details.ViewModel;
using DCT.MVVM;
using DCT.Service;
using DCT.Service.Data;
using DCT.Store;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DCT.List.ViewModel
{
    public class CoinListViewModel : ViewModelBase
    {
        private readonly CoinApiService coinService;
        private readonly Navigation navigation;

        public CoinListViewModel(CoinApiService coinService, Navigation navigation)
        {
            this.coinService = coinService;
            this.navigation = navigation;
            List = new();
            ViewDetailsCommand = new DelegateCommand<CoinDto>(ShowCoinDetails);

            LoadCoins();
        }

        private async void LoadCoins()
        {
            List.Clear();
            var coinsList = await coinService.GetTopCoins();
            foreach (var coin in coinsList)
            {
                List.Add(new CoinsListItemViewModel(coin));
            }
        }

        private void ShowCoinDetails(CoinDto coin)
        {
            navigation.SetViewModel<CoinDetailsViewModel>(coin);
        }

        public ObservableCollection<CoinsListItemViewModel> List { get; private set; }
        public ICommand ViewDetailsCommand { get; private set; }
    }
}
