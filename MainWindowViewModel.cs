using DCT.Store;
using System;
using System.ComponentModel;

namespace DCT
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly Navigation _navigationStore;

        public event PropertyChangedEventHandler? PropertyChanged;

        public INotifyPropertyChanged CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainWindowViewModel(Navigation navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.ViewModelChanged += NavigationStore_ViewModelChanged;
        }

        private void NavigationStore_ViewModelChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentViewModel)));
        }

        public void Dispose()
        {
            _navigationStore.ViewModelChanged -= NavigationStore_ViewModelChanged;
        }
    }
}
