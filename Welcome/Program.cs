using Welcome.ViewModel;
using Welcome.Model;
using Welcome.View;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {

            User user = new User();
            user.Name = "John Doe";
            user.Password = "ReallyStrongPassword";
            user.Role = Others.UserRoleEnum.ADMIN;

            UserViewModel userViewModel = new UserViewModel(user);
            UserView userView = new UserView(userViewModel);    
            userView.DisplayWelcomePage();

            Console.ReadLine(); 

        }
    }
}
