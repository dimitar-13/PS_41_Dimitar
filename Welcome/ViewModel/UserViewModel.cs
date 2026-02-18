using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Helpers;
using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User user;

        public string UserName { get {return this.user.Name; } set { this.user.Name = value; } }

        public string UserPassword {
            get {return this.user.Password; } 
            set {this.user.Password = value; } 
        }

        public UserRoleEnum UserRole { get {return this.user.Role; } set {this.user.Role = value; } }

        public string FacultyNumber { get { return this.user.FacultyNumber; } set { this.user.FacultyNumber = value; } }

        public string Email { get { return this.user.Email; } set { this.user.Email = value; } }

        public UserViewModel(User user)
        {
            this.user = user;
        }

    }
}
