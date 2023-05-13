using Autofac;
using Autofac.Core;
using DCT.MVVM;
using System;
using System.ComponentModel;

namespace DCT.Store
{
    public class Navigation
    {
        private INotifyPropertyChanged? currentViewModel;
        private readonly ILifetimeScope container;

        public Navigation(ILifetimeScope container)
        {
            this.container = container;
        }

        public event Action ViewModelChanged = () => { };

        public INotifyPropertyChanged? CurrentViewModel {
            get { return currentViewModel; }
            set {
                currentViewModel = value;
                ViewModelChanged();
            }
        }

        public void SetViewModel<TViewModel>(params object[] param) where TViewModel : ViewModelBase
        {
            var typedParameters = new Parameter[param.Length];
            for (var i = 0; i < param.Length; i++)
            {
                typedParameters[i] = new TypedParameter(param[i].GetType(), param[i]);
            }
            CurrentViewModel = container.Resolve<TViewModel>(typedParameters);
        }

    }
}
