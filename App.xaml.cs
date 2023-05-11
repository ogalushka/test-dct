using Autofac;
using DCT.Details.View;
using DCT.Details.ViewModel;
using DCT.List.View;
using DCT.List.ViewModel;
using DCT.MVVM.Autofac;
using DCT.Service;
using DCT.Store;
using System;
using System.Net.Http;
using System.Windows;

namespace DCT
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var rootView = new MainWindow();
            var container = BuildContainer(rootView);

            var navigation = container.Resolve<Navigation>();
            navigation.SetViewModel<CoinListViewModel>();

            var mainWindowVM = container.Resolve<MainWindowViewModel>();
            rootView.DataContext = mainWindowVM;
            rootView.Show();
        }

        private ILifetimeScope BuildContainer(MainWindow mainWindow)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Navigation>().SingleInstance();

            builder.RegisterType<MainWindowViewModel>();
            builder.RegisterViewWithBinding<CoinListViewModel, CoinListView>(mainWindow);
            builder.RegisterViewWithBinding<CoinDetailsViewModel, CoinDetailsView>(mainWindow);
            builder.RegisterType<HttpClient>().SingleInstance();

            builder.RegisterType<CoinApiService>().SingleInstance();
            return builder.Build();
        }
    }
}
