using DataLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Commands;
using UI.Core;
using Welcome.Model;
using Welcome.Others;

namespace UI.ViewModel
{
    class MainWindowViewModel : BaseViewModelWindow
    {

        private UserService service;

        private string userName;
        public string UserName
        {
            get { return userName; }
            set 
            { 
                if(userName != value)
                {
                    userName = value;
                    this.OnPropertyChanged(nameof(UserName));
                }
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    this.OnPropertyChanged(nameof(Password));
                }
            }
        }

        private UserRoleEnum userSelectedRole;
        public UserRoleEnum UserSelectedRole
        {
            get { return userSelectedRole; }
            set
            {
                if (userSelectedRole != value)
                {
                    userSelectedRole = value;
                    this.OnPropertyChanged(nameof(UserSelectedRole));
                }

            }
        }

        public IEnumerable<UserRoleEnum> UserRoles => Enum.GetValues(typeof(UserRoleEnum)).Cast<UserRoleEnum>();

        private RegisterUserCommand registerUserCommand = new RegisterUserCommand();

        private ViewDatabaseCommand viewDatabaseCommand = new ViewDatabaseCommand();

        private LogInCommand logInCommand = new LogInCommand();

        public RegisterUserCommand RegisterUserCommand
        {
            get { return this.registerUserCommand; } 
        }
        public ViewDatabaseCommand ViewDatabaseCommand
        { 
            get { return this.viewDatabaseCommand; }
        }

        public LogInCommand LogInCommand
        {
            get { return this.logInCommand; }
        }

        public MainWindowViewModel(UserService userService)
        {
            this.service = userService;
        }
        private void ClearUserData()
        {
            this.UserName = string.Empty;
            this.Password = string.Empty;   
            this.UserSelectedRole = UserRoleEnum.NONE;
        }


        public bool IsUserDataValid()
        {
            if(string.IsNullOrEmpty(this.UserName))
            {
                return false;
            }




            return true;
        }
        public void RegisterUser()
        {

            User userToAdd = new User();
            userToAdd.Name = this.userName;
            userToAdd.Password = this.password;
            userToAdd.Role = this.userSelectedRole;

            int userID = service.AddUser(userToAdd);

            if (userID < 0)
            {
                // Log smth
                return;
            }

            this.ClearUserData();
        }

        public User? LogInUser()
        {
            var users = service.GetAllUsers();
            return users.FirstOrDefault(u => u.Name == this.UserName && u.Password == this.Password);
        }

    }
}
