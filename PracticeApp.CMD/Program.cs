using PracticeApp.BL.Controller;
using PracticeApp.BL.Model;
using System;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace PracticeApp.CMD
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the FitnessApp.");

            Console.Write("Enter the user's name: ");
            var name = GetNotEmptyString(Console.ReadLine());

            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.Write("Enter the user's gender: ");
                var gender = GetNotEmptyString(Console.ReadLine());

                DateTime dateOfBirth;
                double weight = GetParsedDouble("weight");
                double height = GetParsedDouble("height");

                dateOfBirth = ParseDateTime();

                userController.SetNewUserData(gender, dateOfBirth, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
        }

        private static DateTime ParseDateTime()
        {
            while (true)
            {
                Console.Write("Enter the user's Date Of Birth (DD.MM.YYYY): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime value))
                {
                    return value;
                }

                Console.WriteLine("Wrong format of the date!");
            }
        }

        private static string GetNotEmptyString(string message)
        {
            while (true)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    Console.WriteLine("You've written an empty string! Try again.");
                    message = Console.ReadLine();
                }

                else
                {
                    break;
                }
            }

            return message;
        }

        private static double GetParsedDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter the user's {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }

                Console.WriteLine($"Wrong format of {name}");
            }
        }
    }
}
