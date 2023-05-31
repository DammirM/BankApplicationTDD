using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication {

    public class NavigationHandler {

        //Navigation system for admins
        public static void AdminNavigationMenu(Admin admin) {

            //Prints out the logged in admin name
            Console.WriteLine($"\nWelcome ADMIN: {admin.Name}");

            bool run = true;
            while (run) {

                Console.WriteLine("\n" +
                    "1. Admin information\r\n" +
                    "2. Create a new customer\r\n" +
                    "3. Logout"
                );

                byte choice;
                if (!byte.TryParse(Console.ReadLine(), out choice))
                    Console.WriteLine("\nNumber 1-3.");

                string name = "";
                string password = "";

                switch (choice) {

                    default: //If not a valid choice
                        Console.WriteLine("Not a valid choice.");
                        break;
                    case 1: //Admin information
                        admin.AdminInfo();
                        BankSystem.PressEnter();
                        break;
                    case 2: //Create new customers
                        BankSystem.CustomerCreation(name,password);
                        BankSystem.PressEnter();
                        break;
                    case 3: //Change exchange rate in USD to SEK
                        admin.AdminUpdateRates();
                        BankSystem.PressEnter();
                        break;
                    case 4: //Log out of Admin
                        Console.WriteLine($"\nLogged out of: {admin.Name}");
                        run = false;
                        LoginHandler.LogIn();
                        break;

                }

            }

        }

        //Navigation system for the users
        public static void NavigationMenu(Customer account) {

            //Prints out the logged in account name
            Console.WriteLine($"\nWelcome: {account.Name}");

            bool run = true;
            while (run) {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"  __  __              
 |  \/  |___ _ _ _  _ 
 | |\/| / -_) ' \ || |
 |_|  |_\___|_||_\_,_|
                ");
                Console.ResetColor();

                Console.WriteLine(
                    "\n1. Check account balance\r\n" +
                    "2. Open new account\r\n" +
                    "3. Transfer between accounts\r\n" +
                    "4. Transfer funds to another costumer\r\n" +
                    "5. Take a loan\r\n" +
                    "6. Open a savings account\r\n" +
                    "7. See my activity log\r\n" +
                    "8. Logout"
                );

                //Choice input
                byte choice;
                if (!byte.TryParse(Console.ReadLine(), out choice))
                    Console.WriteLine("\nNumber 1-7.");

                Customer customer;
                string transferTo, transferFrom, transfer;

                switch (choice) {

                    default: //If not a valid choice
                        Console.WriteLine("Not a valid choice.");
                        break;
                    case 1: //Check account balance
                        Console.WriteLine($"All accounts for {account.Name}");
                        account.CustomerInfo();
                        BankSystem.PressEnter();
                        break;
                    case 2: //Open new account
                        while (true)
                        {
                            
                            Console.WriteLine("What do you want to name your new account(between 4 and 20 characters)");
                            string newAccChoice = Console.ReadLine();
                            if (newAccChoice.Length > 20 || newAccChoice.Length < 4)
                            {
                                Console.WriteLine("The account name needs to be between 4 and 20 characters");
                            }

                            Console.WriteLine("Which currency do you want to use? \n Available types of currency:\n kr \n $");
                            string curchoice = Console.ReadLine();

                            if (curchoice.ToLower() == "kr" && curchoice == "$")
                            {
                                Console.WriteLine("Invalid choice, try again");
                            }

                            BankSystem.OpenAccount(account, newAccChoice, curchoice);
                            break;
                        }
                        BankSystem.PressEnter();
                        break;
                    case 3: //Transfer between accounts
                        BankSystem.TransferbetweenAccounts(account);
                        BankSystem.PressEnter();
                        break;
                    case 4: //Transfer between customers
                        BankSystem.TransferBetweenCustomers(account);
                        BankSystem.PressEnter();
                        break;
                    case 5: //Take a loan
                        BankSystem.Loan(account);
                        BankSystem.PressEnter();
                        break;
                    case 6:
                        BankSystem.SavingsAccount(account);
                        BankSystem.PressEnter();
                        break;
                    case 7: //See the logged activites of the user
                        BankSystem.SeeLog(account);
                        BankSystem.PressEnter();
                        break;
                    case 8: //Log out of customer
                        Console.WriteLine($"\nLogged out of: {account.Name}");
                        string sendlog = $"{DateTime.Now}: {account.Name} logged out";
                        BankSystem.Log(account, sendlog);
                        run = false;
                        LoginHandler.LogIn();
                        break;

                }

            }

        }

    }

}
