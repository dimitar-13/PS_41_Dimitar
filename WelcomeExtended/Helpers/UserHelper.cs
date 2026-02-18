using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Helpers;
using Welcome.Model;
using WelcomeExtended.Data;
using WelcomeExtended.Others;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {

        public static string ToUserString(this User user)
        {
            return $"User: {user.Name}, Role: {user.Role}, Faculty Number: {user.FacultyNumber}, Email: {user.Email}";
        }

        public static bool ValidateCredentials(this UserData userData, string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                Delegates.Log("Validation failed: Name or password is null or empty.");
                return false;
            }

            return userData.ValidateUser(name, password);
        }

        public static User GetUser(this UserData userData , string name, string password)
        {
            return userData.GetUser(name, password);
        }

    }
}
