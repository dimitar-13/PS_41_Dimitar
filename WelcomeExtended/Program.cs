using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserData userData = new UserData();
            User studentOne = new User
            {
                Name = "student",
                Password = "123",
                Role = UserRoleEnum.STUDENT,
                FacultyNumber = "123456",
            };
            userData.AddUser(studentOne);
            User studentTwo = new User
            {
                Name = "student2",
                Password = "123",
                Role = UserRoleEnum.STUDENT,
                FacultyNumber = "123456",
            };
            userData.AddUser(studentTwo);

            User teacher = new User
            {
                Name = "Teacher",
                Password = "1234",
                Role = UserRoleEnum.PROFESSOR,
                FacultyNumber = "123456",
            };
            userData.AddUser(teacher);

            User admin = new User
            {
                Name = "Admin",
                Password = "12345",
                Role = UserRoleEnum.ADMIN,
                FacultyNumber = "123456",
            };
            userData.AddUser(admin);

            Console.WriteLine("Enter username");
            string userInputUsername = Console.ReadLine();
            Console.WriteLine("Enter password");
            string userInputPassword = Console.ReadLine();

            try
            {
                User sessionUser = null;
                if (!userData.ValidateCredentials(userInputUsername, userInputPassword))
                {
                    Delegates.LogUserFailedLoginAttempt($"Failed to log in with credentials:" +
                        $"name:{userInputUsername} and password:{userInputPassword} at {DateTime.UtcNow.ToString("dd.MM.yyyy")}");
                    throw new Exception("Invalid username or password or user doesnt exist");
                }
                    sessionUser = userData.GetUser(userInputUsername, userInputPassword);
                string sessionUserToString = sessionUser.ToUserString();
                Delegates.LogUserLogin($"{sessionUserToString} logged in {DateTime.UtcNow.ToString("dd.MM.yyyy")}");

                Console.WriteLine(sessionUserToString);
            }
            catch (Exception ex)
            {
                var log = new ActionOnError(Delegates.Log);
                log(ex.Message);
            }
        }
    }
}
