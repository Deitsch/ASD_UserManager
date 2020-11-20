using System;
using Application;
using Application.Contract;
using Infrastructure;
using Microsoft.Data.Sqlite;

namespace ASD_UserManager
{
    class Program
    {
        static ICreateAccountUseCase createAccountUC;
        static IAccountRepository accountRepo;

        static void Main(string[] args)
        {
            Init();
            MainMenu();
        }

        static void Init()
        {
            var context = new SQLiteContext();
            accountRepo = new AccountRepository(context);
            createAccountUC = new CreateAccountUseCase(accountRepo);
        }

        static void MainMenu()
        {
            Console.WriteLine("Options: \n1. Login\n2. Register");
            Console.Write(":");
            int decision = Convert.ToInt32(Console.ReadLine());
            switch (decision) {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    MainMenu();
                    break;
            }
        }

        static void Register()
        {
            Console.Write("Username: ");
            String username = Console.ReadLine();
            Console.Write("Password: ");
            String password = Console.ReadLine();
            Console.Write("Repeat Password: ");
            String passwordRepeat = Console.ReadLine();
            Console.Write("Firstname: ");
            String firstName = Console.ReadLine();
            Console.Write("Lastname: ");
            String lastName = Console.ReadLine();

            var req = new CreateAccountRequest(firstName, lastName, username, password, passwordRepeat);
            var resp = createAccountUC.Execute(req);
            Console.WriteLine(resp.Message);
            MainMenu();
        }

        static void Login()
        {
            Console.Write("Username: ");
            String username = Console.ReadLine();
            Console.Write("Password: ");
            String password = Console.ReadLine();
        }
    }
}