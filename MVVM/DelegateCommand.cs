using System;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DCT.MVVM
{
    public class DelegateCommand : ICommand
    {
        private readonly Action executeAction;
        private readonly Func<bool> canExecute;

        public DelegateCommand(Action executeAction, Func<bool>? canExecute = null)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute ?? DefaultCanExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return canExecute.Invoke();
        }

        public void Execute(object? parameter)
        {
            executeAction.Invoke();
        }

        public void InvokeCanExecuteChanged(EventArgs? args = null)
        {
            CanExecuteChanged?.Invoke(this, args ?? EventArgs.Empty);
        }

        private bool DefaultCanExecute()
        {
            return true;
        }
    }

    public class DelegateCommandAsync : ICommand
    {
        private readonly Func<Task> executeAction;
        private readonly Func<bool> canExecute;
        private bool executing = false;

        public DelegateCommandAsync(Func<Task> executeAction, Func<bool>? canExecute = null)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute ?? DefaultCanExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return !executing && canExecute.Invoke();
        }

        public async void Execute(object? parameter)
        {
            try
            {
                executing = true;
                InvokeCanExecuteChanged();
                await executeAction.Invoke();
            }
            finally
            {
                executing = false;
                InvokeCanExecuteChanged();
            }
        }

        public void InvokeCanExecuteChanged(EventArgs? args = null)
        {
            CanExecuteChanged?.Invoke(this, args ?? EventArgs.Empty);
        }

        private bool DefaultCanExecute()
        {
            return true;
        }
    }
    public class DelegateCommand<Param> : ICommand
    {
        private readonly Action<Param> executeAction;
        private readonly Func<bool> canExecute;

        public DelegateCommand(Action<Param> executeAction, Func<bool>? canExecute = null)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute ?? DefaultCanExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return canExecute.Invoke();
        }

        public void Execute(object? parameter)
        {
            if (parameter is Param typed)
            {
                executeAction.Invoke(typed);
            }
            else
            {
                var actualParam = parameter != null ? parameter.GetType().ToString() : "null";
                Debug.Assert(false, $"Command executed with unsupported typeparam actual {actualParam} expected type {nameof(Param)}");
            }
        }

        public void InvokeCanExecuteChanged(EventArgs? args = null)
        {
            CanExecuteChanged?.Invoke(this, args ?? EventArgs.Empty);
        }

        private bool DefaultCanExecute()
        {
            return true;
        }
    }

    public class DelegateCommandAsync<Param> : ICommand
    {
        private readonly Func<Param, Task> executeAction;
        private readonly Func<bool> canExecute;
        private bool executing = false;

        public DelegateCommandAsync(Func<Param, Task> executeAction, Func<bool>? canExecute = null)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute ?? DefaultCanExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return !executing && canExecute.Invoke();
        }

        public async void Execute(object? parameter)
        {
            try
            {
                executing = true;
                InvokeCanExecuteChanged();
                if (parameter is Param typed)
                {
                    await executeAction.Invoke(typed);
                }
                else
                {
                    var actualParam = parameter != null ? parameter.GetType().ToString() : "null";
                    Debug.Assert(false, $"Command executed with unsupported typeparam actual {actualParam} expected type {nameof(Param)}");
                }
            }
            finally
            {
                executing = false;
                InvokeCanExecuteChanged();
            }
        }

        public void InvokeCanExecuteChanged(EventArgs? args = null)
        {
            CanExecuteChanged?.Invoke(this, args ?? EventArgs.Empty);
        }

        private bool DefaultCanExecute()
        {
            return true;
        }
    }
}
