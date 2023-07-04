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
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Enter the user's gender: ");
                var gender = GetNotEmptyString(Console.ReadLine());

                DateTime dateOfBirth;
                double weight = GetParsedDouble("weight");
                double height = GetParsedDouble("height");

                dateOfBirth = ParseDateTime("Date Of Birth");

                userController.SetNewUserData(gender, dateOfBirth, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("\tE - write the last meal");
                Console.WriteLine("\tA - write an exercise");
                Console.WriteLine("\tQ - quit the program");

                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.food, foods.weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        //var exercise = new Exercise(exe.start, exe.finish, exe.activity, userController.CurrentUser);

                        exerciseController.Add(exe.Activity, exe.Start, exe.Finish);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
                        }

                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static (Activity Activity, DateTime Start, DateTime Finish) EnterExercise()
        {
            Console.WriteLine("Enter exercise's name: ");
            var name = GetNotEmptyString(Console.ReadLine());

            var energy = GetParsedDouble("amount of calories burned");

            var start = ParseDateTime("time of starting the exercise");
            var finish = ParseDateTime("time of finishing the exercise");

            var activity = new Activity(name, energy);
            return (activity, start, finish);
        }

        private static (Food food, double weight) EnterEating()
        {
            Console.Write("Enter the food's name: ");
            var foodName = GetNotEmptyString(Console.ReadLine());

            var calories = GetParsedDouble("calories");
            var proteins = GetParsedDouble("proteins");
            var fats = GetParsedDouble("fats");
            var carbs = GetParsedDouble("carbs");

            var weight = GetParsedDouble("weight");
            var food = new Food(foodName, proteins, fats, carbs, calories);

            return (food, weight);
        }

        private static DateTime ParseDateTime(string date)
        {
            while (true)
            {
                Console.Write($"Enter the user's {date} (DD.MM.YYYY): ");
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

                Console.WriteLine($"Wrong format of the {name}");
            }
        }
    }
}
