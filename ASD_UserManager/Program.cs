using System;
using Application;
using Application.Contract;
using Application.Exceptions;
using ASD_UserManager.Extensions;
using ASD_UserManager.ViewModels;
using Domain.Exceptions;
using Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ASD_UserManager
{
    enum Actions
    {
        Login = 1,
        Register,
    }

    class Program
    {
        static IAccountRepository accountRepository;
        static ICreateAccountUseCase createAccountUC;
        static ILoginUseCase loginUC;

        static LoggedInContext loggedInContext;

        static void Main(string[] args)
        {
            Init();
            DisplayMainMenu();
        }

        static void Init()
        {
            var options = new DbContextOptionsBuilder<SQLiteContext>().UseSqlite("Filename=Database.db").Options;
            var context = new SQLiteContext(options);
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            accountRepository = new AccountRepository(context);
            createAccountUC = new CreateAccountUseCase(accountRepository);
            loginUC = new LoginUseCase(accountRepository);
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Options: \n" + Actions.Login + ". Login\n" + Actions.Register + ". Register");
            Console.Write(":");
            int decision = Convert.ToInt32(Console.ReadLine());
            HandleSelection(decision);
        }

        static void HandleSelection(int decision)
        {
            switch (decision)
            {
                case (int)Actions.Login:
                    ExecuteOption(Login);
                    break;
                case (int)Actions.Register:
                    ExecuteOption(RegisterAccount);
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    DisplayMainMenu();
                    break;
            }
        }

        //Todo: Move to MenuExecutionHandler
        static void ExecuteOption(Action option)
        {
            try
            {
                option.Invoke();
            }
            //TODO: refactor
            catch (Exception exception) when (exception is DomainException || exception is AppException)
            {
                Console.WriteLine(exception.Message);
            }
            DisplayMainMenu();
        }

        static void Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            var request = new LoginRequest(username, password);
            var response = loginUC.Execute(request);
            ForwardToLoginContext(response.toAccountInfoViewModel());
        }

        static void ForwardToLoginContext(AccountInfo accountInfo)
        {
            loggedInContext = new LoggedInContext(accountRepository, accountInfo);
            loggedInContext.DisplayMainMenu();
        }

        static void RegisterAccount()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Repeat Password: ");
            string passwordRepeat = Console.ReadLine();
            Console.Write("Firstname: ");
            string firstName = Console.ReadLine();
            Console.Write("Lastname: ");
            string lastName = Console.ReadLine();

            var req = new CreateAccountRequest(firstName, lastName, username, password, passwordRepeat);
            createAccountUC.Execute(req);
            Console.WriteLine("Account created!");
        }
    }
}