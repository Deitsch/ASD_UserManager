using System;

namespace Domain
{
    public class Account
    {
        public readonly string UserName;

        string Password;

        public readonly string FirstName;

        public readonly string LastName;

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
