using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Account
    {
        public Guid Id;

        public string UserName;

        string Password;

        public string FirstName;

        public string LastName;

        public Account() { } 

        public Account(string userName, string password, string firstName, string lastName)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}
