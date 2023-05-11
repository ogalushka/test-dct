using DCT.MVVM;
using DCT.Service.Data;

namespace DCT.List.ViewModel
{
    public class CoinsListItemViewModel : ViewModelBase
    {
        public CoinDto Dto { get; private set; }

        public CoinsListItemViewModel(CoinDto dto)
        {
            Dto = dto;
            Name = dto.Name;
            Price = dto.PriceUsd;
        }

        private string name = string.Empty;
        public string Name {
            get { return name; }
            set { SetField(ref name, value); }
        }

        private string price = string.Empty;
        public string Price {
            get { return price; }
            set { SetField(ref price, value); }
        }
    }
}
