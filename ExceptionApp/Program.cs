using System;
using System.IO;

namespace ExceptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileFullPath = Path.Combine(Environment.CurrentDirectory, "PhoneBook.txt");
            var phoneBookHandler = new PhoneBookHandler(fileFullPath);
            if (phoneBookHandler.Accounts == null)
            {
                Console.WriteLine("Create phonebook? Enter 'y' or 'n'");
                if (Console.ReadLine().Contains("n"))
                {
                    CloseApp("Application closed");
                }
                int quantityAccounts = 0;
                try
                {
                    Console.WriteLine("Enter quantity accounts for phone book");
                    quantityAccounts = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine($"Invalid format input data \n{formatEx.Message}");
                    CloseApp("Application halted");
                }
                var phoneBookCreator = new PhoneBookCreator(quantityAccounts);
                phoneBookCreator.SaveDataToFile(fileFullPath);
                phoneBookHandler.Accounts = phoneBookCreator.Accounts;
            }
            bool repeatIt = false;
            do
            {
                phoneBookHandler.PrintManual();
                var userInputHandler = new UserInputHandler();
                try
                {
                    userInputHandler.CheckInput(Console.ReadLine());
                    phoneBookHandler.ProcessUserInput(userInputHandler.UserInput);
                    repeatIt = true;
                }
                catch (InvalidUserInputException ex)
                {
                    Console.WriteLine(ex.Message);
                    repeatIt = userInputHandler.Iterate;
                }
                catch (UserHaltException ex)
                {
                    Console.WriteLine(ex.Message);
                    repeatIt = false;
                }
            } while (repeatIt);
            Console.WriteLine("For continue press any key...");
            Console.ReadKey();
        }

        public static void CloseApp(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
