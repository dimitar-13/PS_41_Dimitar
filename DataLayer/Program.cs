using DataLayer.Database;
using DataLayer.Logger;
using DataLayer.Model;
using DataLayer.Service;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography;
using Welcome.Helpers;
using Welcome.Model;
using Welcome.Others;


class Program
{
    public static UserService userService;
    public static List<User> users;
    public static DataBaseLogger dbLogger;
    static void Main(string[] args)
    {
        using (var ctx = new DatabaseContext())
            ctx.Database.EnsureCreated();

        dbLogger = new DataBaseLogger("DbLogger");

        userService = new UserService(dbLogger);
        users = new List<User>();


        Program.ShowMenu();
        Console.ReadKey();
    }

    private static void ShowMenu()
    {
        bool isExit = false;

        while (!isExit)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Get all users");
            Console.WriteLine("2. Delete user");
            Console.WriteLine("3. Add user");
            Console.WriteLine("4. Exit");

            var options = Console.ReadLine();
            int optionIntCast;

            if (int.TryParse(options, out optionIntCast))
            {
                switch (optionIntCast)
                {
                    case 1:
                        Console.WriteLine("Get all users");
                        Program.GetAllUsers();
                        break;
                    case 2:
                        Console.WriteLine("Delete user");
                        DeleteUser();
                        break;
                    case 3:
                        AddUser();
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option");
            }
        }
    }

    public static void GetAllUsers()
    {
        var users = userService.GetAllUsers();

        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Role: {user.Role}, Faculty Number: {user.FacultyNumber}, Expires: {user.Expires}, Email: {user.Email}");
        }
    }

    public static bool DeleteUser()
    {
        Console.WriteLine("Enter username");
        string userInputUsername = Console.ReadLine();
        Console.WriteLine("Enter password");
        string userInputPassword = Console.ReadLine();

        var users = userService.GetAllUsers();

        var userToDelete = users.FirstOrDefault(u => u.Name == userInputUsername && u.Password == userInputPassword);

        if (userToDelete == null)
        {
            // Log
            return false;
        }
        userService.DeleteUserById(userToDelete.Id);

        return true;   
    }

    public static void AddUser()
    {
        Console.WriteLine("Enter username");
        string userInputUsername = Console.ReadLine();
        Console.WriteLine("Enter password");
        string userInputPassword = Console.ReadLine();
        Console.WriteLine("Enter role");
        EnumHelper.PrintAllEnum();
        string userInputRole = Console.ReadLine().ToUpper();

        User user = new User();

        user.Name = userInputUsername;
        user.Password = userInputPassword;
        user.Role = EnumHelper.StringToUserRoleEnum(userInputRole);

        int userID = userService.AddUser(user);

        if (userID != -1)
        {
            users.Add(userService.GetUserById(userID));
        }
    }
}