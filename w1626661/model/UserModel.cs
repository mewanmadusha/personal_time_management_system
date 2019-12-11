using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w1626661.model
{
    public class UserModel
    {
        private int id;
        private string name;
        private string userName;
        private string password;
        private string confPassword;

        public string Name { get => name; set => name = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string ConfPassword { get => confPassword; set => confPassword = value; }
        public int Id { get => id; set => id = value; }
    }
}
