using Domain.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Account
    {
        public readonly Guid Id;

        public readonly string UserName;

        string Password;

        public readonly string FirstName;

        public readonly string LastName;

        bool IsUserLoggedIn;

        public Account() { } 

        public static Account Create(NewAccount newAccount)
        {
            if(newAccount.Password != newAccount.RepeatedPassword)
            {
                throw new PasswordException("Passwords are not matching!");
            }
            return new Account(Guid.NewGuid(), newAccount);
        }
        
        private Account(Guid id, NewAccount newAccount)
        {
            Id = id;
            UserName = newAccount.UserName;
            Password = newAccount.Password;
            FirstName = newAccount.FirstName;
            LastName = newAccount.LastName;
            IsUserLoggedIn = false;
        }

        public void ChangePassword(NewPassword newPassword)
        {
            if (newPassword.Password == newPassword.RepeatedPassword)
                throw new PasswordException("Password is not matching");

            if (newPassword.Password == Password)
                throw new PasswordException("Password is similar to old one!");

            Password = newPassword.Password;
        }

        public void Login(string password)
        {
            if (password != Password)
            {
                throw new PasswordException("Password is wrong!");
            }

            IsUserLoggedIn = true;
        }

        public void LogOut()
        {
            IsUserLoggedIn = false;
        }
    }
}
