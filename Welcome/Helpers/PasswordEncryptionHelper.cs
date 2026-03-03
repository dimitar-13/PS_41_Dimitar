using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welcome.Helpers
{
    public static class PasswordEncryptionHelper
    {
        public static string EncryptPassword(string password)
        {
            char[] passwordChars = password.ToCharArray();
            Array.Reverse(passwordChars);
            return new string(passwordChars);
        }

        public static string DecryptPassword(string encryptedPassword)
        {
            char[] passwordChars = encryptedPassword.ToCharArray();
            Array.Reverse(passwordChars);
            return new string(passwordChars);
        }

    }
}
