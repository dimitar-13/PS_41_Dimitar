using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Others
{
    public class Delegates
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("Hello");
        public static readonly ILogger fileLogger = LoggerHelper.GetFileLogger("FileLogger");
        public static readonly ILogger UserLoginLogger = LoggerHelper.GetFileLogger("UserLogin");
        public static readonly ILogger UserFailedLoginLogger = LoggerHelper.GetFileLogger("UserFailedAttempt");


        public static void Log(string error)
        {
            Delegates.logger.LogError(error);
        }

        public static void LogToFile(string message)
        {
            Delegates.fileLogger.LogInformation(message);
        }
        public static void LogUserLogin(string message)
        {
            Delegates.UserLoginLogger.LogInformation(message);
        }
        public static void LogUserFailedLoginAttempt(string error)
        {
            Delegates.UserFailedLoginLogger.LogInformation(error);
        }

        public static void LogById(int eventId)
        {
           if (Delegates.logger is IHashLogger loggerCast)
                loggerCast.LogByEventID(eventId);
        }
        public static void LogAll()
        {
            if (Delegates.logger is IHashLogger loggerCast)
                loggerCast.PrintAllLogs();
        }
        public static void DeleteLog(int eventId)
        {
            if (Delegates.logger is IHashLogger loggerCast)
                loggerCast.RemoveByEventID(eventId);
        }
        public static void Log2(string error)
        {
            Console.WriteLine("- DELEGATES -");
                Console.WriteLine($"{error}");
            Console.WriteLine("- DELEGATES -");
        }
    }
}
