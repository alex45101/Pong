using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace signInPong
{
    public class Player
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email{get;set;}

        public Player(string name, string password, string email)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
