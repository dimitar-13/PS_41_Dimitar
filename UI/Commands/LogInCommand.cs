using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.VIew.Popups;
using UI.ViewModel;

namespace UI.Commands
{
    class LogInCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var VMcast = (MainWindowViewModel)parameter;
            if (VMcast != null)
            {
                var loggedInUser = VMcast.LogInUser();

                var popup = new LogInPopUpWindow();
                popup.DataContext = new LoginViewModel(loggedInUser);
                popup.Show();
            }
        }
    }
}
