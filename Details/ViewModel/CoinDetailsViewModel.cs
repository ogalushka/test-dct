using DCT.MVVM;
using DCT.Service.Data;

namespace DCT.Details.ViewModel
{
    public class CoinDetailsViewModel : ViewModelBase
    {
        private CoinDto coinDto;

        public CoinDetailsViewModel(CoinDto coinDto)
        {
            this.coinDto = coinDto;
        }

        public string CoinName => coinDto.Name;
    }
}
