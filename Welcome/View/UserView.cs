using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {

        private UserViewModel userViewModel;

        public UserView(UserViewModel userViewModel)
        {
            this.userViewModel = userViewModel;
        }

        public void DisplayWelcomePage()
        {
            string text = string.Format("Welcome\nUser:{0}\n Roles:{1}", userViewModel.UserName, userViewModel.UserRole.ToString());

            Console.WriteLine(text);
        }

        public void DisplayUserInfo()
        {
            string text = string.Format("User Info\nUser:{0}\nFacultyNumber:{1}\nEmail:{2}", userViewModel.UserName, userViewModel.FacultyNumber, userViewModel.Email);
            Console.WriteLine(text);
        }

        public void DisplayError()
        {
            throw new Exception("Testing exception!");
        }
    }
}
