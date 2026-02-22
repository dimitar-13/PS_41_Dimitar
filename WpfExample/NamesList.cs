using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfExample.Commands;

namespace WpfExample
{
    public class NamesList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private AddCommand addNameCommand = new AddCommand();
        private RemoveCommand removeNameCommand = new RemoveCommand();


        private string firstName = "";
        private string lastName = "";
        private string selectedName = "";

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (firstName != value)
                {
                    firstName = value;

                    OnPropertyChanged("FirstName");
                }
            }
        }

        public AddCommand AddNameCommand 
        {
            get { return addNameCommand; }
        }
        public RemoveCommand RemoveNameCommand
        {
            get => removeNameCommand;
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (lastName != value)
                {
                    lastName = value;

                    OnPropertyChanged("LastName");
                }
            }
        }

        public string SelectedName
        {
            get
            {
                return selectedName;
            }
            set
            {
                if (selectedName != value)
                {
                    selectedName = value;

                    OnPropertyChanged("SelectedName");
                }
            }
        }

        public ObservableCollection<string> Names{ get; private set; }

        public NamesList()
        {
            Names = new ObservableCollection<string>();
        }

        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
