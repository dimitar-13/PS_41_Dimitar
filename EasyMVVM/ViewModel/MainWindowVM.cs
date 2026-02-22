using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMVVM.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<string> backingProperty;

        public ObservableCollection<string> BoundProperty
        {
            get { return backingProperty; }
            set { backingProperty = value; PropChanged("BoundProperty"); }
        }


        public MainWindowVM()
        {
            Model model = new Model();
            backingProperty = model.GetData();
        }


        public void PropChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
