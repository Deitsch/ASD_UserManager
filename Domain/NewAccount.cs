using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public struct NewAccount
    {
        public readonly string FirstName;

        public readonly string LastName;

        public readonly string UserName;

        public readonly string Password;

        public readonly string RepeatedPassword;

        public NewAccount(string firstName, string lastName, string userName, string password, string repeatedPassword)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            RepeatedPassword = repeatedPassword;
        }
    }
}
