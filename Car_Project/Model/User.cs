using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project
{
    public class User
    {
        public User()
        {

        }
        public User(string name, string password, string rights)
        {
            this.Name = name;
            this.Password = password;
            this.Rights = rights;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Rights { get; set; }
    }
}
