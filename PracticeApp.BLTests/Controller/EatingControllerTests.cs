using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeApp.BL.Controller;
using PracticeApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();

            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);

            var random = new Random();
            var food = new Food(foodName, random.Next(50, 500), random.Next(50, 500), random.Next(50, 500), random.Next(50, 500));

            // Act
            eatingController.Add(food, 100);
        }
    }
}