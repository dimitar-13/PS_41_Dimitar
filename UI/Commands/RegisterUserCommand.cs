using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;

            MainWindowViewModel viewModel = (MainWindowViewModel)parameter;
            return viewModel.IsUserDataValid();
        }

        public void Execute(object? parameter)
        {
            MainWindowViewModel viewModel = (MainWindowViewModel)parameter;
            viewModel.RegisterUser();
        }
    }
}
