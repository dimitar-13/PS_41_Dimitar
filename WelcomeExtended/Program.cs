using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Helpers;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                User user = new User();
                user.Name = "John Doe";
                user.Password = "ReallyStrongPassword";
                user.Role = UserRoleEnum.ADMIN;

                UserViewModel userViewModel = new UserViewModel(user);
                UserView userView = new UserView(userViewModel);
                userView.Display();

                // Throws exception for testing
                userView.DisplayError();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                var log = new ActionOnError(Delegates.Log);
                log(ex.Message);
            }
            finally
            {
                Console.WriteLine("Everything is executed");
            }
        }
    }
}
