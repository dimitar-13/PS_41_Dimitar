using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.VIew;

namespace UI.Commands
{
    class ViewDatabaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var databaseView = new DatabaseViewWindow();
            databaseView.DataContext = databaseView;   
            databaseView.Show();
        }
    }
}
