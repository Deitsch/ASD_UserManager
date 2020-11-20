using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public struct NewPassword
    {
        public readonly string Password;

        public readonly string RepeatedPassword;

        public NewPassword(string password, string repeatedPassword)
        {
            Password = password;
            RepeatedPassword = repeatedPassword;
        }
    }
}
