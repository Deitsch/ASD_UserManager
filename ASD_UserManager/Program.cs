using System;

namespace ASD_UserManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
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
            String password1 = Console.ReadLine();
            Console.Write("Repeat Password: ");
            String password2 = Console.ReadLine();
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
