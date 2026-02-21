using DataLayer.Database;
using DataLayer.Logger;
using DataLayer.Mapper;
using DataLayer.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Helpers;
using Welcome.Model;

namespace DataLayer.Service
{
    public class UserService
    {
        private DataBaseLogger logger = new DataBaseLogger(nameof(UserService));

        public UserService(DataBaseLogger logger)
        {
            this.logger = logger;
        }

        public int AddUser(User user)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    var newUser = new DatabaseUser
                    {
                        Name = user.Name,
                        Password = user.Password,
                        Role = user.Role,
                        FacultyNumber = user.FacultyNumber,
                        Expires = user.Expires,
                        Email = user.Email
                    };
                    var addedUser = context.Users.Add(newUser);
                    context.SaveChanges();

                    logger.LogInformation("Added User at {0}", DateTime.UtcNow);

                    return addedUser.Entity.Id;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }

        public void DeleteUserById(int userId)
        {

            using (var context = new DatabaseContext())
            {
                try
                {
                    var userToDelete = context.Users.Find(userId);
                    if (userToDelete != null)
                    {
                        context.Users.Remove(userToDelete);
                        context.SaveChanges();
                        logger.LogInformation("Removed User at {0}", DateTime.UtcNow);
                    }
                    else
                    {
                        throw new Exception($"User with ID {userId} not found.");
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public List<User> GetAllUsers()
        {
            using (var context = new DatabaseContext())
            {
                var users = context.Users.Select(u => UserMapper.MapUserFromDataUser(new User(), u)).ToList();
                return users;
            }
        }

        public User GetUserById(int userId)
        {
            using (var context = new DatabaseContext())
            {
                var user = context.Users.Find(userId);
                if (user != null)
                {
                    return UserMapper.MapUserFromDataUser(new User(), user);
                }
                else
                {
                    throw new Exception($"User with ID {userId} not found.");
                }
            }
        }
    }
}
