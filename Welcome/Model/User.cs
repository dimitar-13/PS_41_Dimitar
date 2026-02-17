using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {

        public string Name { get { return this.names; } set { this.names = value; } }
        public string Password { get { return this.password; } set { this.password = value; } }
        public UserRoleEnum Role { get { return this.role; } set { this.role = value; } }


        private string names;
        private string password;
        private UserRoleEnum role;

    }
}
