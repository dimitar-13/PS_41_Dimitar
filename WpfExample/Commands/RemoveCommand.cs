using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExample.Commands
{
    public class RemoveCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return parameter != null;
        }

        public void Execute(object? parameter)
        {
            var nameList = parameter as NamesList;
            var OldName = nameList.SelectedName;

            nameList.Names.Remove(OldName);
        }
    }
}
