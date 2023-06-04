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

            Console.WriteLine("Enter the user's name: ");
            var name = GetNotEmptyString(Console.ReadLine());

            Console.WriteLine("Enter the user's gender: ");
            var gender = GetNotEmptyString(Console.ReadLine());

            Console.WriteLine("Enter the user's date of birth: ");
            var dateOfBirth = DateTime.Parse(GetNotEmptyString(Console.ReadLine()));

            Console.WriteLine("Enter the user's weight: ");
            var weight = double.Parse(GetNotEmptyString(Console.ReadLine()));

            Console.WriteLine("Enter the user's height: ");
            var height = double.Parse(GetNotEmptyString(Console.ReadLine()));

            var userController = new UserController(name, gender, dateOfBirth, weight, height);
            userController.Save();
        }

        static string GetNotEmptyString(string message)
        {
            while (true)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    Console.WriteLine(message + " can not be empty!");
                    message = Console.ReadLine();
                }

                else
                {
                    break;
                }
            }

            return message;
        }
    }
}
