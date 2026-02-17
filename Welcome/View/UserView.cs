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

        public void Display()
        {
            string text = string.Format("Welcome \n User:{0}\n Roles:{1}",userViewModel.UserName,userViewModel.UserRole.ToString());

            Console.WriteLine(text);
        }
    }
}
