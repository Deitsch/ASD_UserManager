using Application;
using Application.Contract;
using ASD_UserManager.ViewModels;
using Domain.Exceptions;
using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ASD_UserManager
{
    public class LoggedInContext
    {
        AccountInfo accountInfo;

        IChangeAccountPasswordUseCase changeAccountPasswordUC;
        ILogoutUseCase logoutUC;
        IDeleteAccountUseCase deleteAccountUC;

        Timer logOutTimer;
        const int TIME_OUT = 60000;


        public LoggedInContext(IAccountRepository accountRepository, AccountInfo accountInfo)
        {
            this.accountInfo = accountInfo;

            deleteAccountUC = new DeleteAccountUseCase(accountRepository);
            changeAccountPasswordUC = new ChangeAccountPasswordUseCase(accountRepository);
            logoutUC = new LogoutUseCase(accountRepository);
            new Timer(o => Logout(), null, TIME_OUT, Timeout.Infinite);
        }
 
        public void DisplayMainMenu()
        {
            Console.WriteLine("Options: \n"
                + (int)UserActions.PrintInfo + ". Print Info\n"
                + (int)UserActions.ChangePW + ". Change Password \n"
                + (int)UserActions.Logout + ". Logout \n"
                + (int)UserActions.DeleteAccount + ". Delete Account");

            Console.Write(":");
            int decision = Convert.ToInt32(Console.ReadLine());
            HandleSelection(decision);
        }

        void HandleSelection(int decision)
        {
            switch (decision)
            {
                case (int)UserActions.PrintInfo:
                    Console.WriteLine($"Username: {accountInfo.UserName}");
                    Console.WriteLine($"Firstname: {accountInfo.FirstName}");
                    Console.WriteLine($"Lastname: {accountInfo.LastName}");
                    DisplayMainMenu();
                    break;
                case (int)UserActions.ChangePW:
                    ExecuteOption(ChangePassword);
                    DisplayMainMenu();
                    break;
                case (int)UserActions.Logout:
                    ExecuteOption(Logout);
                    return;
                case (int)UserActions.DeleteAccount:
                    ExecuteOption(DeleteAccount);
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    DisplayMainMenu();
                    break;
            }
        }

        //Todo: Move to MenuExecutionHandler
        void ExecuteOption(Action option)
        {
            try
            {
                option.Invoke();
                Console.WriteLine("Execution was successfull!");
            }
            //TODO: refactor
            catch (Exception exception) when(exception is DomainException || exception is AppException)
            {
                Console.WriteLine(exception.Message);
                DisplayMainMenu();
            }
        }

        void Logout()
        {
            Console.WriteLine("Logging out...");
            var request = new LogoutRequest(accountInfo.UserName);
            logoutUC.Execute(request);
            Console.WriteLine("User logged out successfully!");
        }

        void DeleteAccount()
        {
            Console.WriteLine("Are you sure about deleting your account? (Y/n)");
            string answer = Console.ReadLine();
            if (answer != "Y")
                return;

            var request = new DeleteAccountRequest(accountInfo.UserName);
            deleteAccountUC.Execute(request);
        }

        void ChangePassword()
        {
            Console.WriteLine("Enter new password: ");
            string newPassword = Console.ReadLine();
            Console.WriteLine("Repeat new password: ");
            string repeatedPassword = Console.ReadLine();

            var request = new ChangeAccountPasswordRequest(accountInfo.UserName, newPassword, repeatedPassword);
            changeAccountPasswordUC.Execute(request);
        }
    }
}
