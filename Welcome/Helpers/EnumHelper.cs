using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Helpers
{
    public static class EnumHelper
    {
        public static UserRoleEnum StringToUserRoleEnum(string stringToConvert)
        {
            switch(stringToConvert)
            {
                case "ANONYMOUS":
                    return UserRoleEnum.ANONYMOUS;
                case "ADMIN":
                    return UserRoleEnum.ADMIN;
                case "INSPECTOR":
                    return UserRoleEnum.INSPECTOR;
                case "PROFESSOR":
                    return UserRoleEnum.PROFESSOR;
                case "STUDENT":
                    return UserRoleEnum.STUDENT;
                default:
                    return UserRoleEnum.NONE;
            }
        }

        public static void PrintAllEnum()
        {
            foreach (var role in Enum.GetValues(typeof(UserRoleEnum)))
            {
                Console.WriteLine($"{role}");
            }
        }

    }
}
