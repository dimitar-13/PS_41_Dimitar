using DataLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Core;
using Welcome.Model;

namespace UI.ViewModel
{
    class LoginViewModel : BaseViewModelWindow
    {

        private User? loggedInUser;
        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                if (message != value)
                {
                    message = value;
                    this.OnPropertyChanged(nameof(Message));
                }
            }
        }

        public LoginViewModel(User? loggedInUser)
        {
            this.loggedInUser = loggedInUser;
            this.GenerateMessage();
        }

        private void GenerateMessage()
        {
            if (loggedInUser != null)
            {
                this.Message = $"User: {loggedInUser.Name} with Role: {loggedInUser.Role} has logged in";
            }
            else
            {
                this.Message = $"Invalid credentials";
            }

        }
    }
}
