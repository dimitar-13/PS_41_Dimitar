using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Helpers;
using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Helpers;
using WelcomeExtended.Others;
namespace WelcomeExtended.Data
{
    public class UserData
    {
        private List<User> users;
        private int nextId;

        public UserData()
        {
            nextId = 0;
            users = new List<User>();
        }

        public void AddUser(User user)
        {
            user.Id = nextId++;
            users.Add(user);
        }

        public void DeleteUser(int id)
        {
            users.RemoveAll(u => u.Id == id);
        }

        public bool ValidateUser(string name, string password)
        {
            foreach (var user in users)
            {
                if (user.Name == name && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateUserLamba(string name, string password)
        {
            return users.Where(u => u.Name == name && u.Password == password).FirstOrDefault() != null;
        }

        public bool ValidateUserLinq(string name,string password)
        {
            var ret = from User user in users
                      where user.Name == name && user.Password == password
                      select user.Id;

            return ret != null;
        }

        public User GetUser(string name, string password)
        {
            var retUser = (from User user in users
                           where user.Name == name && user.Password == password
                           select user).FirstOrDefault();

            if ( retUser == null)
            {
                Delegates.Log($"User with name{name} not found");
                return null;
            }

            return retUser;
        }

        public bool SetActive(string name, DateTime newDate)
        {
            var restUser = (from User user in users
                      where user.Name == name
                      select user).FirstOrDefault();

            if (restUser != null)
            {
                restUser.Expires = newDate;
                return true;
            }

            Delegates.Log($"User with name{name} not found");
            return false;
        }


        public bool AsignUserRole(string name, UserRoleEnum newRole)
        {
            var restUser = (from User user in users
                            where user.Name == name
                            select user).FirstOrDefault();
            if (restUser != null)
            {
                restUser.Role = newRole;
                return true;
            }
            Delegates.Log($"User with name{name} not found");
            return false;
        }   

    }
}
