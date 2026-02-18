using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Helpers;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public int Id { get { return this.id; } set { this.id = value; } }
        public DateTime Expires { get { return this.expires; } set { this.expires = value; } }
        public string Name { get { return this.names; } set { this.names = value; } }
        public string Password { get { return PasswordEncryptionHelper.DecryptPassword(this.password); } set { this.password = PasswordEncryptionHelper.EncryptPassword(value); } }
        public UserRoleEnum Role { get { return this.role; } set { this.role = value; } }
        public string FacultyNumber { get { return this.facultyNumber; } set { this.facultyNumber = value; } }

        public string Email { get { return this.email; } set { this.email = value; } }

        private int id;
        private DateTime expires;
        private string names;
        private string password;
        private UserRoleEnum role;
        private string facultyNumber;
        private string email;
    }
}
