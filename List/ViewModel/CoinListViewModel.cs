using DCT.Details.ViewModel;
using DCT.MVVM;
using DCT.Service;
using DCT.Service.Data;
using DCT.Store;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
            ShowTop10Command = new DelegateCommandAsync(ShowTop10);
            SearchCommand = new DelegateCommandAsync(Search);

            _ = ShowTop10();
        }

        private async Task ShowTop10()
        {
            List.Clear();
            var coinsList = await coinService.GetTopCoins();
            foreach (var coin in coinsList)
            {
                List.Add(new CoinsListItemViewModel(coin));
            }
        }

        private async Task Search()
        {
            var coinsList = await coinService.Search(SearchQuery);

            List.Clear();
            foreach (var coin in coinsList)
            {
                List.Add(new CoinsListItemViewModel(coin));
            }
        }

        private void ShowCoinDetails(CoinDto coin)
        {
            navigation.SetViewModel<CoinDetailsViewModel>(coin);
        }

        private string searchQuery = string.Empty;
        public string SearchQuery {
            get { return searchQuery; }
            set { SetField(ref searchQuery, value); }
        }

        public ObservableCollection<CoinsListItemViewModel> List { get; private set; }

        public ICommand ViewDetailsCommand { get; private set; }
        public ICommand ShowTop10Command { get; private set; }
        public ICommand SearchCommand { get; private set; }
    }
}
