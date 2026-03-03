using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;

namespace DataLayer.Mapper
{
    public static class UserMapper
    {
        public static User MapUserFromDataUser(this User User, DatabaseUser dataUser )
        {
            User.Id = dataUser.Id;
            User.Name = dataUser.Name;
            User.Password = dataUser.Password;
            User.Role = dataUser.Role;
            User.FacultyNumber = dataUser.FacultyNumber;
            User.Email = dataUser.Email;

            return User;
        }

        public static DatabaseUser MapDataUserFromUser(this DatabaseUser dataUser, User user)
            {
                dataUser.Id = user.Id;
                dataUser.Name = user.Name;
                dataUser.Password = user.Password;
                dataUser.Role = user.Role;
                dataUser.FacultyNumber = user.FacultyNumber;
                dataUser.Email = user.Email;
    
                return dataUser;
        }
    }
}
